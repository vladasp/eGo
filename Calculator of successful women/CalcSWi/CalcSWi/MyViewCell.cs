using System;

using Foundation;
using UIKit;

namespace CalcSWi
{
    public partial class MyViewCell : UITableViewCell
    {

        public string Message
        {
            get { return MyMessage.Text; }
            set { MyMessage.Text = value; }
        }

        protected MyViewCell(IntPtr handle) : base(handle)
        {
            
        }
    }
}
