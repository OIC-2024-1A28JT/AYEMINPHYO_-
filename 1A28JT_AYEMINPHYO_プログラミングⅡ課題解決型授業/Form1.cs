using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace _1A28JT_AYEMINPHYO_プログラミングⅡ課題解決型授業
{
    public partial class Form1 : Form
    {
        // 接続文字列を修正。ここではそのままの形で利用しています。
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ayemi\\source\\repos\\1A28JT_AYEMINPHYO_プログラミングⅡ課題解決型授業\\1A28JT_AYEMINPHYO_プログラミングⅡ課題解決型授業\\Database.mdf;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            //showZantaka();
        }

        int balance = 0;
        int zantaka;

        //private void showZantaka()
        //{
        //    int zantaka = CalculateBalance();

        //    zantakaLbl.Text = String.Format("残高 : {0}", zantaka);
        //}

        // 収入ボタンのクリックイベント
        private void Incomebtn_Click(object sender, EventArgs e)
        {
            // 金額が正しいかどうかを確認
            if (int.TryParse(Inputbox.Text, out int money))
            {
                int balance = CalculateBalance();
                balance += money;
                ResultLbl.Text = String.Format("残高 : ¥{0}", balance);

                //zantakaLbl.Text = String.Format("残高 : ¥{0}", zantaka);

                // 収入をデータベースに保存
                SaveTransaction(money, "Income", datebox.Text);

            }
            else
            {
                ResultLbl.Text = "無効な金額です。正の数を入力してください。";
            }

            // 日付の検証
            if (IsValidDate(datebox.Text))
            {
                ResultDate.Text = "日付: " + datebox.Text;  // 正しい日付が入力された場合、表示する
            }
            else
            {
                ResultDate.Text = "無効な日付です。正しい日付を入力してください。";
            }
        }

        // 支出ボタンのクリックイベント
        private void Outcomebtn_Click(object sender, EventArgs e)
        {
            // 金額が正しいかどうかを確認
            if (int.TryParse(Inputbox.Text, out int money))
            {
                try
                {
                    int balance = CalculateBalance();
                    balance -= money;
                    //balance = getBanalce();
                    // 残高が負になった場合、エラーをスロー
                    if (balance < 0)
                    {
                        throw new NegativeResultException("支出金額が残高金額を上回っているので支出できません。");
                    }

                    ResultLbl.Text = String.Format("残高 : ¥{0}", balance);

                    //zantakaLbl.Text = String.Format("残高 : ¥{0}", zantaka);

                    // 支出をデータベースに保存
                    SaveTransaction(money, "Expense", datebox.Text);
                }
                catch (NegativeResultException ex)
                {
                    // エラーメッセージのみ表示
                    ResultLbl.Text = ex.Message;
                }
            }
            else
            {
                ResultLbl.Text = "無効な金額です。正の数を入力してください。";
            }

            // 日付の検証
            if (IsValidDate(datebox.Text))
            {
                ResultDate.Text = "日付: " + datebox.Text;  // 正しい日付が入力された場合、表示する
            }
            else
            {
                ResultDate.Text = "無効な日付です。正しい日付を入力してください。";
            }
        }

        // 自作の例外クラス
        public class NegativeResultException : Exception
        {
            public NegativeResultException(string message) : base(message)
            {
            }
        }

        // 日付が有効かどうかを確認するメソッド
        private bool IsValidDate(string date)
        {
            return DateTime.TryParse(date, out _);
        }

        // 取引データをデータベースに保存するメソッド
        private void SaveTransaction(int amount, string type, string transactionDate)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Transactions (Amount, TransactionType, TransactionDate) VALUES (@Amount, @TransactionType, @TransactionDate)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Amount", amount);
                        cmd.Parameters.AddWithValue("@TransactionType", type);
                        cmd.Parameters.AddWithValue("@TransactionDate", DateTime.Parse(transactionDate));

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("データベースの操作中にエラーが発生しました: " + ex.Message);
                }
            }
        }

        // 現在の残高を計算するメソッド
        private int CalculateBalance()
        {
            int totalIncome = 0;
            int totalExpense = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string incomeQuery = "SELECT SUM(Amount) FROM Transactions WHERE TransactionType = 'Income'";
                    string expenseQuery = "SELECT SUM(Amount) FROM Transactions WHERE TransactionType = 'Expense'";

                    // 収入の合計を取得
                    using (SqlCommand cmd = new SqlCommand(incomeQuery, connection))
                    {
                        var result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            totalIncome = Convert.ToInt32(result);
                        }
                    }

                    // 支出の合計を取得
                    using (SqlCommand cmd = new SqlCommand(expenseQuery, connection))
                    {
                        var result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            totalExpense = Convert.ToInt32(result);
                        }
                    }
                    zantaka = totalIncome - totalExpense;
                    return zantaka;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("残高計算中にエラーが発生しました: " + ex.Message);
                    return 0;
                }
            }
        }

    }
}
