using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomChannelCreator.Models
{
    public class CustomListBoxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public CustomListBoxItem(string text, string value)
        {
            this.Text = text;
            this.Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
