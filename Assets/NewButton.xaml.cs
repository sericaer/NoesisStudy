#if UNITY_5_3_OR_NEWER
#define NOESIS
using Noesis;
using UnityEngine;
#else
using System;
using System.Windows;
using System.Windows.Controls;
#endif
using System.Windows.Input;


namespace NoesisStudy.Assets
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
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
}
