using ReactiveUI;
using System.Windows.Forms;
using System;
using System.Reactive.Disposables;


namespace ThirdLab
{
    public partial class TLView : Form, IViewFor<TLViewModel>
    {
        public TLView()
        {
            InitializeComponent();
            ViewModel = new TLViewModel();
            this.WhenActivated(a =>
            {
                a(this.Bind(ViewModel, vm => vm.PointScalar, v => v.multiplyPointScalarBox.Text));
                a(this.Bind(ViewModel, vm => vm.PointSetScalar, v => v.multiplyPointSetBox.Text));
                a(this.Bind(ViewModel, vm => vm.EqualityCheckPoint, v => v.equalityCheckPointBox.Text));
                a(this.Bind(ViewModel, vm => vm.EqualityCheckPointSet, v => v.equalityCheckPointSetBox.Text));
                a(this.Bind(ViewModel, vm => vm.UnEqualityCheckPoint, v => v.unEqualityCheckPointBox.Text));
                a(this.Bind(ViewModel, vm => vm.UnEqualityCheckPointSet, v => v.unEqualityCheckPointSetBox.Text));
                a(this.Bind(ViewModel, vm => vm.OffsetPointSet, v => v.offsetPointSetBox.Text));
                a(this.Bind(ViewModel, vm => vm.IsAdditionOffsetOperation, v => v.offsetPointSetOperationPlusButton.Checked));
                a(this.OneWayBind(ViewModel, vm => vm.PointMultiplyResult, v => v.multiplyPointResultBox.Text));
                a(this.OneWayBind(ViewModel, vm => vm.PointSetMultiplyResult, v => v.multiplyPointSetResultBox.Text));
                a(this.OneWayBind(ViewModel, vm => vm.PointEqualityCheckResult, v => v.equalityCheckPointResultBox.Text));
                a(this.OneWayBind(ViewModel, vm => vm.PointSetEqualityCheckResult, v => v.equalityCheckPointSetResultBox.Text));
                a(this.OneWayBind(ViewModel, vm => vm.PointUnEqualityCheckResult, v => v.unEqualityCheckPointResultBox.Text));
                a(this.OneWayBind(ViewModel, vm => vm.PointSetUnEqualityCheckResult, v => v.unEqualityCheckPointSetResultBox.Text));
                a(this.OneWayBind(ViewModel, vm => vm.OffsetPointSetResult, v => v.offsetPointSetResultBox.Text));
                a(this.BindCommand(ViewModel, vm => vm.PointMultiply, v => v.multiplyPointButton));
                a(this.BindCommand(ViewModel, vm => vm.PointSetMultiply, v => v.multiplyPointSetButton));
                a(this.BindCommand(ViewModel, vm => vm.PointEqualityCheck, v => v.equalityCheckPointButton));
                a(this.BindCommand(ViewModel, vm => vm.PointSetEqualityCheck, v => v.equalityCheckPointSetButton));
                a(this.BindCommand(ViewModel, vm => vm.PointUnEqualityCheck, v => v.unEqualityCheckPointButton));
                a(this.BindCommand(ViewModel, vm => vm.PointSetUnEqualityCheck, v => v.unEqualityCheckPointSetButton));
                a(this.BindCommand(ViewModel, vm => vm.PointSetOffset, v => v.offsetPointSetButton));
            });
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (TLViewModel)value;
        }

        public TLViewModel ViewModel { get; set; }
    }
}
