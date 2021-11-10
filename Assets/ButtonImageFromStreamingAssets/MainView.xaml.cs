#if UNITY_5_3_OR_NEWER
#define NOESIS
using Noesis;
using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using UnityEngine;
#else
using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
#endif

namespace NoesisStudy.ButtonImageFromStreamingAssets
{
    /// <summary>
    /// Interaction logic for NoesisStudyMainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }

#if NOESIS
        private void InitializeComponent()
        {
            NoesisUnity.LoadComponent(this);
        }
#endif
    }

    //public class ImageDetailConverter : IMultiValueConverter
    //{
    //    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    public class ImageDetailConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
#if NOESIS
            var fileData = File.ReadAllBytes(@"D:\git\NoesisStudy\Assets\StreamingAssets\flower.jpg");
            var tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);

            return new TextureSource(tex);
#else
            var image = new BitmapImage(new Uri(@"D:\git\NoesisStudy\Assets\StreamingAssets\flower.jpg"));
            return image;
#endif
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageBrush brush = new ImageBrush();
            return null;
        }
    }

    public class ImageBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(!(value is ImageBrush))
            {
                return value;
            }

#if NOESIS
            var fileData = File.ReadAllBytes(@"D:\git\NoesisStudy\Assets\StreamingAssets\flower.jpg");
            var tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);

            return new ImageBrush(new TextureSource(tex));
#else
            var image = new BitmapImage(new Uri(@"D:\git\NoesisStudy\Assets\StreamingAssets\flower.jpg"));

            return new ImageBrush(image);
#endif
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageBrush brush = new ImageBrush();
            return null;
        }
    }

    public class ImageFileLoader : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
