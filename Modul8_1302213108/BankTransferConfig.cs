using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Modul8_1302213108
{
    public class BankTransferConfig
    {
        public BankTransferConfig config { get; set; }
        public string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public string configFileName = "bank_transfer_config.json";
        private string lang;
        public BankTransferConfig() 
        {
            try
            {
                ReadConfig();
            }
            catch
            {
                setDefault();
                WriteConfig();
            }
        }
        private BankTransferConfig ReadConfig()
        {
            string jsonFronFile = File.ReadAllText(path+ '/' + configFileName);
            config = JsonSerializer.Deserialize<BankTransferConfig>(jsonFronFile);
            return config;
        }

        private void WriteConfig()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            
            String jsonString = JsonSerializer.Serialize(config, options);
            string fullPath = path + '/' + configFileName;
            File.WriteAllText(fullPath, jsonString);
        }

        public void setDefault()
        {
            config = new BankTransferConfig();
        }

        public void ProgramCONFIG1()
        {
            config.lang = config.lang == "en" ? "id" : "en";
        }

        public void CONFIG1()
        {
            if(config.lang == "en")
            {
                Console.WriteLine("Please insert the amount of money to transfer:");
            }
            else if(config.lang == "id")
            {
                Console.WriteLine("Masukkan Jumlah Uang yang Akan Di Transfer: ");
            }
            else
            {
                Console.WriteLine("EROR");
            }
        }
        
        public void Transaksi()
        {

        }

        public class Config
        {
            public string lang { get; set; }
            public int threshold { get; set; }
            public int low_fee { get; set; }
            public int high_fee { get; set; }
            public string methods { get; set; }
            public string en { get; set; }
            public string id { get; set; }

            public Config() { }

            public Config(string lang, int threshold, int low_fee, int high_fee, string methods, string en, string id)
            {
                this.lang = lang;
                this.threshold = threshold;
                this.low_fee = low_fee;
                this.high_fee = high_fee;
                this.methods = methods;
                this.en = en;
                this.id = id;
            }
        }
    }
}
