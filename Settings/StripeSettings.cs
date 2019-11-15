using ConfigurationValidation.Settings.Validations;
using System;

namespace ConfigurationValidation.Settings
{
    public class StripeSettings : ISettingsValidator
    {
        public string ApiKey { get; set; }

        public void Check()
        {
            if (string.IsNullOrWhiteSpace(ApiKey)) throw new ArgumentNullException("StripeSettings.ApiKey value is not valid");
        }
    }
}