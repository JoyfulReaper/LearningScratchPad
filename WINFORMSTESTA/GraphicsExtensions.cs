// Wanted something that mimic the OLD VB way of doing it
// Thank you SO: https://stackoverflow.com/questions/1835062/drawing-circles-with-system-drawing

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WINFORMSTESTA
{
    public static class GraphicsExtensions
    {
        public static void DrawCircle(this Graphics g, Pen pen,
                                      float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }

        public static void FillCircle(this Graphics g, Brush brush,
                                      float centerX, float centerY, float radius)
        {
            g.FillEllipse(brush, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }
    }
}
