using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeweyDecimalClassLibrary
{
    public class Line
    {
        /// <summary>
        /// Stores the name of the source label (the label that is being dragged)
        /// </summary>
        public string sourceLabelName { get; set; }

        /// <summary>
        /// Stores the name of the receiver label (the label that has been dragged to)
        /// </summary>
        public string receiverLabelName { get; set; }

        /// <summary>
        /// Stores the location of the source label
        /// </summary>
        public Point sourceLabelLocation { get; set; }

        /// <summary>
        /// Stores the location of the receiver label
        /// </summary>
        public Point receiverLabelLocation { get; set; }

        //----------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// Class constructor
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public Line(Point start, Point end, string SourceLabelName, string ReceiverLabelName)
        {
            sourceLabelLocation = start;
            receiverLabelLocation = end;
            sourceLabelName = SourceLabelName;
            receiverLabelName = ReceiverLabelName;
        }
    }
}