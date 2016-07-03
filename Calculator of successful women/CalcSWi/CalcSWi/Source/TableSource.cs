using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace CalcSWi
{
    class TableSource : UITableViewSource
    {
        IList<string> _objects;
        public const string CellIdentifier = "MyCell";

        public TableSource(IList<string> objects)
        {
            _objects = objects;
        }

        public override nint RowsInSection(UITableView tableview, nint section) => _objects.Count;

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell (CellIdentifier, indexPath) ?? new UITableViewCell (UITableViewCellStyle.Default, CellIdentifier);
            cell.TextLabel.Text = _objects[indexPath.Row];
            return cell;
        }
    }
}
