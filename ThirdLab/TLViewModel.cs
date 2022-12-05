using ReactiveUI;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Forms;
using System;
using static ThirdLab.TLModel;

namespace ThirdLab
{
    public class TLViewModel : ReactiveObject
    {
        private string _pointScalar;
        public string PointScalar
        {
            get => _pointScalar;
            set => this.RaiseAndSetIfChanged(ref _pointScalar, value);
        }

        private string _pointMultiplyResult;
        public string PointMultiplyResult
        {
            get => _pointMultiplyResult;
            set => this.RaiseAndSetIfChanged(ref _pointMultiplyResult, value);
        }

        private string _pointSetScalar;
        public string PointSetScalar
        {
            get => _pointSetScalar;
            set => this.RaiseAndSetIfChanged(ref _pointSetScalar, value);
        }

        private string _pointSetMultiplyResult;
        public string PointSetMultiplyResult
        {
            get => _pointSetMultiplyResult;
            set => this.RaiseAndSetIfChanged(ref _pointSetMultiplyResult, value);
        }

        private string _equalityCheckPoint;
        public string EqualityCheckPoint
        {
            get => _equalityCheckPoint;
            set => this.RaiseAndSetIfChanged(ref _equalityCheckPoint, value);
        }

        private bool _pointEqualityCheckResult;
        public bool PointEqualityCheckResult
        {
            get => _pointEqualityCheckResult;
            set => this.RaiseAndSetIfChanged(ref _pointEqualityCheckResult, value);
        }

        private string _equalityCheckPointSet;
        public string EqualityCheckPointSet
        {
            get => _equalityCheckPointSet;
            set => this.RaiseAndSetIfChanged(ref _equalityCheckPointSet, value);
        }

        private bool _pointSetEqualityCheckResult;
        public bool PointSetEqualityCheckResult
        {
            get => _pointSetEqualityCheckResult;
            set => this.RaiseAndSetIfChanged(ref _pointSetEqualityCheckResult, value);
        }

        private string _unEqualityCheckPoint;
        public string UnEqualityCheckPoint
        {
            get => _unEqualityCheckPoint;
            set => this.RaiseAndSetIfChanged(ref _unEqualityCheckPoint, value);
        }

        private bool _pointUnEqualityCheckResult;
        public bool PointUnEqualityCheckResult
        {
            get => _pointUnEqualityCheckResult;
            set => this.RaiseAndSetIfChanged(ref _pointUnEqualityCheckResult, value);
        }

        private string _unEqualityCheckPointSet;
        public string UnEqualityCheckPointSet
        {
            get => _unEqualityCheckPointSet;
            set => this.RaiseAndSetIfChanged(ref _unEqualityCheckPointSet, value);
        }

        private bool _pointSetUnEqualityCheckResult;
        public bool PointSetUnEqualityCheckResult
        {
            get => _pointSetUnEqualityCheckResult;
            set => this.RaiseAndSetIfChanged(ref _pointSetUnEqualityCheckResult, value);
        }

        private string _offsetPointSet;
        public string OffsetPointSet
        {
            get => _offsetPointSet;
            set => this.RaiseAndSetIfChanged(ref _offsetPointSet, value);
        }

        private string _offsetPointSetResult;
        public string OffsetPointSetResult
        {
            get => _offsetPointSetResult;
            set => this.RaiseAndSetIfChanged(ref _offsetPointSetResult, value);
        }

        private bool _isAdditionOffsetOperation;
        public bool IsAdditionOffsetOperation
        {
            get => _isAdditionOffsetOperation;
            set => this.RaiseAndSetIfChanged(ref _isAdditionOffsetOperation, value);
        }


        public TLViewModel()
        {
            PointMultiply = ReactiveCommand
                .Create(() => PointMultiplyResult = PointMultiply(PointScalar));
            PointMultiply.ThrownExceptions.Subscribe(error => MessageBox.Show(error.Message, "Внимание!"));
            
            PointSetMultiply = ReactiveCommand
                .Create(() => PointSetMultiplyResult = PointSetMultiply(PointSetScalar));
            PointSetMultiply.ThrownExceptions.Subscribe(error => MessageBox.Show(error.Message, "Внимание!"));

            PointEqualityCheck = ReactiveCommand
                .Create(() => PointEqualityCheckResult = PointEqualityCheck(EqualityCheckPoint));
            PointEqualityCheck.ThrownExceptions.Subscribe(error => MessageBox.Show(error.Message, "Внимание!"));

            PointSetEqualityCheck = ReactiveCommand
                .Create(() => PointSetEqualityCheckResult = PointSetEqualityCheck(EqualityCheckPointSet));
            PointSetEqualityCheck.ThrownExceptions.Subscribe(error => MessageBox.Show(error.Message, "Внимание!"));

            PointUnEqualityCheck = ReactiveCommand
                .Create(() => PointUnEqualityCheckResult = PointUnEqualityCheck(UnEqualityCheckPoint));
            PointUnEqualityCheck.ThrownExceptions.Subscribe(error => MessageBox.Show(error.Message, "Внимание!"));

            PointSetUnEqualityCheck = ReactiveCommand
                .Create(() => PointSetUnEqualityCheckResult = PointSetUnEqualityCheck(UnEqualityCheckPointSet));
            PointSetUnEqualityCheck.ThrownExceptions.Subscribe(error => MessageBox.Show(error.Message, "Внимание!"));

            PointSetOffset = ReactiveCommand
                .Create(() => OffsetPointSetResult = PointSetOffset(OffsetPointSet, IsAdditionOffsetOperation));
            PointSetOffset.ThrownExceptions.Subscribe(error => MessageBox.Show(error.Message, "Внимание!"));
        }

        public ReactiveCommand<Unit, string> PointMultiply { get; private set; }
        public ReactiveCommand<Unit, string> PointSetMultiply { get; private set; }
        public ReactiveCommand<Unit, bool> PointEqualityCheck { get; private set; }
        public ReactiveCommand<Unit, bool> PointSetEqualityCheck { get; private set; }
        public ReactiveCommand<Unit, bool> PointUnEqualityCheck { get; private set; }
        public ReactiveCommand<Unit, bool> PointSetUnEqualityCheck { get; private set; }
        public ReactiveCommand<Unit, string> PointSetOffset { get; private set; }
    }
}

