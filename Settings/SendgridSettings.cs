using ConfigurationValidation.Settings.Validations;
using System;

namespace ConfigurationValidation.Settings
{
    public class SendgridSettings : ISettingsValidator
    {
        public string RepositoryUrl { get; set; }

        public void Check()
        {
            if (!Uri.TryCreate(RepositoryUrl, UriKind.Absolute, out var _))
            {
                throw new Exception("SendgridSettings.RepositoryUrl is not a valid url");
            }
        }
    }
}
