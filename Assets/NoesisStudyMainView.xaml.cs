#if UNITY_5_3_OR_NEWER
#define NOESIS
using Noesis;
using System.Windows.Input;
using UnityEngine;
#else
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
#endif

namespace NoesisStudy
{
    /// <summary>
    /// Interaction logic for NoesisStudyMainView.xaml
    /// </summary>
    public partial class NoesisStudyMainView : UserControl
    {
        public static NoesisStudyMainView inst;

        public NoesisStudyMainView()
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
            Debug.Log("MyCommand Execute");
#endif

                var path = "Assets/NewButton.xaml";
                var page = Application.LoadComponent(new System.Uri(path, System.UriKind.Relative));
                var finded = NoesisStudyMainView.inst.FindName("Container") as StackPanel;
                finded.Children.Add(page as UIElement);
            }
        }
    }
}
