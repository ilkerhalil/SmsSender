using System.Configuration;

namespace SmsSender.Vodafone
{
    public class VodafoneSmsProviderConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("UserName", IsRequired = true)]
        public string UserName
        {
            get { return this["UserName"] as string; }
            set { this["UserName"] = value; }
        }
        [ConfigurationProperty("Password", IsRequired = true)]
        public string Password
        {
            get
            {
                return this["Password"] as string;
            }
            set
            {
                this["Password"] = value;
            }
        }
        [ConfigurationProperty("Header", IsRequired = true)]
        public string Header
        {
            get
            {
                return this["Header"] as string;
            }
            set
            {
                this["Header"] = value;
            }
        }
    }
}