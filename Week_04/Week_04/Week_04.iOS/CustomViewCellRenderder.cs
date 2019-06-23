using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Week_04;
using Week_04.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(CustomViewCell), typeof(CustomViewCellRenderder))]
namespace Week_04.iOS
{
   
        public class CustomViewCellRenderder : ViewCellRenderer
        {
           
            public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
            {
                var cell = base.GetCell(item, reusableCell, tv);
                var view = item as CustomViewCell;

                cell.SelectedBackgroundView = new UIView
                {
                    BackgroundColor = view.SelectedItemBackgroundColor.ToUIColor(),
                };

                return cell;
            }
        }
    }
