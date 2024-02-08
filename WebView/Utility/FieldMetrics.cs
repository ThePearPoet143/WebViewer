using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WebView.Utility
{
    public class FieldMetrics
    {
        public DoubletF PicSize { get; private set; }      //size of the display (in display pixels)
        public DoubletF SlideSize { get; private set; }     //size of 1x2 inch slide deposition area (microns)
        public Doublet DisplaySize { get; private set; }    //size of a field display object (pixels)
        public int Level { get; private set; }              //0=lm, 1=hm
        int _selectedObjective;                             //the objective in use 
        Doublet[] _displaySizes;                            //display field size (pixels) by objective
        DoubletF _selectedFieldSize;                        //slide field size by objective(microns)
        public DoubletF FieldCentroid { get; set; }                     //centroid location in slide-relative microns
        DoubletF[] _pixelSizeInMicron;                                  //ordered by objective power
        DoubletF[] _fieldSizeInMicron;                                  //ordered by objective power

        public FieldMetrics(DoubletF picSize)
        {
            PicSize = new DoubletF(picSize);
            SlideSize = new DoubletF(25400, 50800);
            _displaySizes = new Doublet[]
            {
                new Doublet(18, 14),        //10x
                new Doublet(9, 7),          //20x
                new Doublet(8, 8),          //40x
                new Doublet(8, 8)           //100x
            };
            GetSelectedLevel();
            GetSelectedObjective();
            ReadFieldSizes();
            GetSelectedFieldSize();
            GetSelectedDisplaySize();
        }

        //return the xy grid position of this field in the deposition area
        //(wont work on hm)
        public Doublet GetGridPosition(DoubletF centroid)
        {
            DoubletF position = new DoubletF(_selectedFieldSize);
            Doublet grid = new Doublet();
            while (position.X < SlideSize.X)
            {
                if (centroid.X < position.X)
                    break;
                position.X += _selectedFieldSize.X;
                ++grid.X;
            }

            while (position.Y < SlideSize.Y)
            {
                if (centroid.Y < position.Y)
                    break;
                position.Y += _selectedFieldSize.Y;
                ++grid.Y;
            }
            return grid;
        }

        //given lm grid position, return display location
        public Doublet DisplayLocation(Doublet grid)
        {
            return grid * DisplaySize;
        }

        //return the object coordinate where the user clicked
        public DoubletF SlideCoordinate(Doublet picLocation)
        {
            DoubletF coord;
            if (Level == 0) //lm
            {
                Doublet gridPosition = new Doublet(picLocation) / DisplaySize;
                coord = (gridPosition.ToDoubletF() * _selectedFieldSize) + _selectedFieldSize / 2f;
            }
            else
                coord = DisplayToCentroid(picLocation); //hm
            return coord;
        }

        //convert field centroid in microns to display pixels
        public Doublet CentroidToDisplay(DoubletF centroid) //micron
        {
            DoubletF pixel = (centroid * PicSize) / SlideSize;
            return pixel.Round().ToDoublet();
        }

        //convert display pixel to field centroid in microns
        public DoubletF DisplayToCentroid(Doublet picLocation) //pixels
        {
            DoubletF centroid = new DoubletF(picLocation.X,picLocation.Y) * (SlideSize / PicSize) - _selectedFieldSize;
            return centroid;
        }

        void GetSelectedLevel()
        {
            //Level = SystemModel.Instance.Server.SelectedLevel;
        }

        //get the index of the selected objective
        void GetSelectedObjective()
        {
            //_selectedObjective = SystemModel.Instance.Metrics.SelectedObjective();
        }

        //return the field size for the selected objective (microns)
        void GetSelectedFieldSize()
        {
            _selectedFieldSize = _fieldSizeInMicron[0];
        }

        //get the display size of a single field with this objective
        void GetSelectedDisplaySize()
        {
            if (_selectedObjective >= 0)
                DisplaySize = _displaySizes[_selectedObjective];
        }

        void ReadPixelSizes()
        {
            _pixelSizeInMicron = new DoubletF[]
            {
                //&&& for new camera
                new DoubletF(0.24f, 0.24f),
                new DoubletF(0.12f, 0.12f),
                new DoubletF(0.06f, 0.06f),
                new DoubletF(0.03f, 0.03f)
                //new DoubletF(0.74f, 0.74f),
                //new DoubletF(0.37f, 0.37f),
                //new DoubletF(0.185f, 0.185f),
                //new DoubletF(0.074f, 0.074f)
            };
        }

        //load field size constants (in ascending objective power order
        void ReadFieldSizes()
        {
            _fieldSizeInMicron = new DoubletF[]
            {
                new DoubletF(1184f, 888f),
                new DoubletF(592f, 444f),
                new DoubletF(296f, 222f),
                new DoubletF(118.4f, 88.8f)
            };
        }

    }
}
