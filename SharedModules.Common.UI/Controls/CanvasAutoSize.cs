using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SharedModules.Common.UI.Controls
{
    public class CanvasAutoSize : Canvas
    {
        protected override Size MeasureOverride(Size constraint)
        {
            base.MeasureOverride(constraint);

            try
            {
                double width =
                    base.InternalChildren.OfType<UIElement>()
                        .Max(
                            i =>
                            {
                                double left = (double)i.GetValue(Canvas.LeftProperty);
                                if (double.IsNaN(left))
                                    left = 0;

                                return i.DesiredSize.Width + left;
                            });

                double height =
                    base.InternalChildren.OfType<UIElement>()
                        .Max(
                            i =>
                            {
                                double top = (double)i.GetValue(Canvas.TopProperty);
                                if (double.IsNaN(top))
                                    top = 0;

                                return i.DesiredSize.Height + top;
                            });

                return new Size(width, height);
            }
            catch (Exception)
            {
                return new Size(0, 0);
            }
        }
    }
}
