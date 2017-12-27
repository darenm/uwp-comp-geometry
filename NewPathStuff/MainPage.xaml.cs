using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NewPathStuff
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            var c = Window.Current.Compositor;
            var visual = ElementCompositionPreview.GetElementVisual(RootGrid);
            var path = c.CreatePathGeometry();

            // Need this so we can add multiple shapes to a sprite
            var shapeContainer = c.CreateContainerShape();

            // Rounded Rectangle - just the rounded rect properties
            var roundedRectangle = c.CreateRoundedRectangleGeometry();
            roundedRectangle.CornerRadius = new Vector2(20);
            roundedRectangle.Size = new Vector2(400, 300);

            // Need to create a sprite shape from the rounded rect
            var roundedRectSpriteShape = c.CreateSpriteShape(roundedRectangle);
            roundedRectSpriteShape.FillBrush = c.CreateColorBrush(Colors.Red);
            roundedRectSpriteShape.StrokeBrush = c.CreateColorBrush(Colors.Green);
            roundedRectSpriteShape.StrokeThickness = 5;
            roundedRectSpriteShape.Offset = new Vector2(20);

            shapeContainer.Shapes.Add(roundedRectSpriteShape);

            var roundedRectSpriteShape2 = c.CreateSpriteShape(roundedRectangle);
            roundedRectSpriteShape2.FillBrush = c.CreateColorBrush(Colors.Purple);
            roundedRectSpriteShape2.StrokeBrush = c.CreateColorBrush(Colors.Yellow);
            roundedRectSpriteShape2.StrokeThickness = 3;
            roundedRectSpriteShape2.Offset = new Vector2(90);
            roundedRectSpriteShape2.CenterPoint = new Vector2(200, 150);
            roundedRectSpriteShape2.RotationAngleInDegrees = 45;

            shapeContainer.Shapes.Add(roundedRectSpriteShape2);


            //// Line
            //var line = c.CreateLineGeometry();
            //line.Start = Vector2.Zero;
            //line.End = new Vector2(1000, 400);
            //line.Comment = "Who knows?";

            //var lineSpriteShape = c.CreateSpriteShape(line);
            //lineSpriteShape.FillBrush = c.CreateColorBrush(Colors.Cyan);
            //lineSpriteShape.StrokeBrush = c.CreateColorBrush(Colors.Purple);
            //lineSpriteShape.StrokeThickness = 7;
            //lineSpriteShape.StrokeDashArray.Add(3);
            //lineSpriteShape.StrokeDashArray.Add(1);


            // This is what we can add as a child to an element
            var shapeVisual = c.CreateShapeVisual();
            shapeVisual.Shapes.Add(shapeContainer);
            //shapeVisual.Shapes.Add(lineSpriteShape);

            shapeVisual.Size = new Vector2(1000, 1000);

            var visualContainer = c.CreateContainerVisual();
            visualContainer.Children.InsertAtBottom(shapeVisual);


            ElementCompositionPreview.SetElementChildVisual(RootGrid, visualContainer);
        }
    }
}
