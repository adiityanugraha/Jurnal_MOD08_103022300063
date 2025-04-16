using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_103022300063
{

    class Transfer
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }
    }

    class Confirmation
    {
        public string en { get; set; }
        public string id { get; set; }
    }

    class BankTransferConfig
    {
        public string lang { get; set; }
        public Transfer transfer { get; set; }
        public Confirmation confirmation { get; set; }
        public List<string> methods { get; set; } = ["RTO, (real-time)", "SKN", "RTGS", "BI", "FAST"];

        string path = Path.GetFullPath("@D: modul8_103022300063\bank_transfer_config.json");

        public BankTransferConfig LoadConf()
        {
            if (!File.Exists(path))
            {
                var defaultSetting = new BankTransferConfig();
                SaveNewConfig(defaultSetting);
                return defaultSetting;
            }

            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<BankTransferConfig>(json);
        }

        public void SaveNewConfig(BankTransferConfig config)
        {
            var json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }

        public void GantiBahasa()
        {
            if (lang.Equals("en"))
            {
                lang = "id";
            }
            else if (lang.Equals("id"))
            {
                lang = "en";
            }
        }
    }
}
