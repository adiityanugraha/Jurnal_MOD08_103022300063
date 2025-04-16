using modul8_103022300063;
using System.Text.Json;
using System;

class Program
{
    static void Main(string[] args)
    {
        BankTransferConfig config = new BankTransferConfig().LoadConf();

        Console.WriteLine("Ubah bahasa saat ini? (y/n)");
            string input = Console.ReadLine();

        if (input.ToLower() == "y")
        {
            config.GantiBahasa();
            config.SaveNewConfig(config);
            Console.WriteLine("Bahasa telah diubah ke: " + config.lang);
        }
        else
        {
            Console.WriteLine("Bahasa tetap: " + config.lang);
        }

        if (config.lang.Equals("en"))
        {
            Console.WriteLine("Please insert the amount of money to transfer: ");
        }
        else
        {
            Console.WriteLine("Silakan masukkan jumlah uang yang akan ditransfer: ");
        }
        int amount = Convert.ToInt32(Console.ReadLine());

        if (amount <= config.transfer.threshold || amount == config.transfer.threshold)
        {
            Console.WriteLine("Transfer fee: " + config.transfer.low_fee);
        }
        else if (amount >= config.transfer.threshold)
        {
            Console.WriteLine("Transfer fee: " + config.transfer.high_fee);
        }
    }
}
