using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BookingApp.Triggers
{
    public class KidAvailableTrigger : TriggerAction<Entry>
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
                if (n < 0)
                {
                    sender.Text = "0";
                }
                else if (n > 3)
                {
                    sender.Text = "3";
                }
            }
        }
    }
}
