using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;

namespace ConfigurationValidation.Settings.Validations
{
    public class GlobalSettingsValidationFilter : IStartupFilter
    {
        private readonly IEnumerable<ISettingsValidator> _items;

        public GlobalSettingsValidationFilter(IEnumerable<ISettingsValidator> items)
        {
            _items = items;
        }

        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            foreach (var items in _items)
            {
                items.Check();
            }

            return next;
        }
    }
}
