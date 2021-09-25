using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BookingApp.Triggers
{
    public class AdultAvailableTrigger : TriggerAction<Entry>
    {
        protected override void Invoke(Entry sender) {
            int n;
            var isNumeric = int.TryParse(sender.Text, out n);
            if (string.IsNullOrWhiteSpace(sender.Text) || !isNumeric)
            {
                sender.Text = "";
            }
            else
            {
                if (n < 1)
                {
                    sender.Text = "1";
                }
                else if (n > 3)
                {
                    sender.Text = "3";
                }
            }
        }
    }
}
