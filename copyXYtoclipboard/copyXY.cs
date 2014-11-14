using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using ESRI.ArcGIS.ArcMapUI;

namespace copyXYtoclipboard
{
    public class copyXY : ESRI.ArcGIS.Desktop.AddIns.Tool
    {
        
        public copyXY()
        {
        }

        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;

        }
        protected override void OnMouseDown(MouseEventArgs arg)
        {
            Clipboard.Clear();
            int X = arg.X;
            int Y = arg.Y;
            
            //base.OnMouseDown(arg);
            //MessageBox.Show("Present!");
            
            
            //ESRI.ArcGIS.Display.IScreenDisplay screenDisplay = (m_application.Document as IMxDocument).ActiveView.ScreenDisplay;
            ESRI.ArcGIS.Display.IScreenDisplay screenDisplay = (ArcMap.Application.Document as IMxDocument).ActiveView.ScreenDisplay;
            ESRI.ArcGIS.Geometry.IPoint point = screenDisplay.DisplayTransformation.ToMapPoint(X, Y);

            //MessageBox.Show("X position is " + point.X.ToString() + "Y position is :" + point.Y.ToString());
            string xy = point.X.ToString() + " " + point.Y.ToString();
            Clipboard.SetText(xy);
        }
        
    }
    

}
