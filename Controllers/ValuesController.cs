using ConfigurationValidation.Settings;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ConfigurationValidation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController
    {
        private readonly StripeSettings _stripeSettings;
        private readonly SendgridSettings _sendgridSettings;

        public ValuesController(StripeSettings settings, SendgridSettings sendgrid)
        {
            _stripeSettings = settings;
            _sendgridSettings = sendgrid;
        }

        [HttpGet]
        public ICollection<object> Get() => new[] { (object)_sendgridSettings, _stripeSettings };
    }
}