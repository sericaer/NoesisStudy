#if UNITY_5_3_OR_NEWER
#define NOESIS
using Noesis;
using System.IO;
using System.Windows.Input;
using UnityEngine;
#else
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
#endif

namespace NoesisStudy.DynamicButton
{
    /// <summary>
    /// Interaction logic for NoesisStudyMainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public static MainView inst;

        public MainView()
        {
            inst = this;

            InitializeComponent();

            this.DataContext = this;
        }

#if NOESIS
        private void InitializeComponent()
        {
            NoesisUnity.LoadComponent(this);
        }

        private static class Application
        {
            public static object LoadComponent(System.Uri uri)
            {
                return Noesis.GUI.LoadXaml(UriHelper.GetPath(uri));
            }
        }
#endif

        public MyCommand ClickCommand
        {
            get
            {
                return new MyCommand();
            }
        }

        public class MyCommand : ICommand
        {

            public MyCommand()
            {
            }

            public event System.EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
#if NOESIS
                var filePath = UnityEngine.Application.dataPath;
#else
                var filePath = "../../../Assets/";
#endif
                var str = File.ReadAllText(filePath + "/DynamicButton/NewButton.xaml");
                object button = XamlReader.Parse(str);

                var finded = MainView.inst.FindName("Container") as StackPanel;
                finded.Children.Add(button as UIElement);


            }
        }
    }
}
