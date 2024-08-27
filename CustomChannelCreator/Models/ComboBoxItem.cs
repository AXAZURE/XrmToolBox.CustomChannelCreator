using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomChannelCreator.Models
{
    public class ComboboxItem
    {
        public string Text { get; set; }
        public Entity Value { get; set; }

        public ComboboxItem(string text, Entity value) {
            this.Text = text;
            this.Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
