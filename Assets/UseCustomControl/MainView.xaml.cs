#if UNITY_5_3_OR_NEWER
#define NOESIS
using Noesis;
#else
using System;
using System.Windows.Controls;
#endif

namespace NoesisStudy.UseCustomControl
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


}

#if NOESIS
namespace CustomControls
{
    /// <summary>
    /// ���ղ��� 1a �� 1b ������Ȼ��ִ�в��� 2 ���� XAML �ļ���ʹ�ô��Զ���ؼ���
    ///
    /// ���� 1a) �ڵ�ǰ��Ŀ�д��ڵ� XAML �ļ���ʹ�ø��Զ���ؼ���
    /// ���� XmlNamespace ������ӵ�Ҫʹ�ø����Եı���ļ��ĸ�
    /// Ԫ����:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomControls"
    ///
    ///
    /// ���� 1b) ��������Ŀ�д��ڵ� XAML �ļ���ʹ�ø��Զ���ؼ���
    /// ���� XmlNamespace ������ӵ�Ҫʹ�ø����Եı���ļ��ĸ�
    /// Ԫ����:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomControls;assembly=CustomControls"
    ///
    /// ������Ҫ���һ���� XAML �ļ����ڵ���Ŀ������Ŀ����Ŀ���ã�
    /// �����������Ա���������:
    ///
    ///     �ڽ��������Դ���������һ�Ŀ����Ŀ��Ȼ�����ε���
    ///     ��������á�->����Ŀ��->[ѡ�����Ŀ]
    ///
    ///
    /// ���� 2)
    /// ������������ XAML �ļ���ʹ�ÿؼ���
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>

    [TemplatePart(Name = "CloseButton", Type = typeof(Button))]
    public class ContentBox : ContentControl
    {
        static ContentBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ContentBox), new FrameworkPropertyMetadata(typeof(ContentBox)));
        }

        protected override void OnApplyTemplate()
        {
            ApplyTemplate();

            var partControlsLayer = GetTemplateChild("CloseButton") as Button;
            partControlsLayer.Click += (sender, e) =>
            {
                var parent = this.Parent as Panel;
                parent.Children.Remove(this);
            };
        }
    }
}
#endif