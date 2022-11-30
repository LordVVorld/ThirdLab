using ReactiveUI;
using System.Reactive;

namespace ThirdLab
{
    public class TLViewModel : ReactiveObject
    {
        private double _pointScalar;
        public double PointScalar
        {
            get => _pointScalar;
            set => this.RaiseAndSetIfChanged(ref _pointScalar, value);
        }

        private string _pointMultiplayResult;
        public string PointMultiplayResult
        {
            get => _pointMultiplayResult;
            set => this.RaiseAndSetIfChanged(ref _pointMultiplayResult, value);
        }

        private double _pointSetScalar;
        public double PointSetScalar
        {
            get => _pointSetScalar;
            set => this.RaiseAndSetIfChanged(ref _pointSetScalar, value);
        }

        private string _pointSetMultiplayResult;
        public string PointSetMultiplayResult
        {
            get => _pointSetMultiplayResult;
            set => this.RaiseAndSetIfChanged(ref _pointSetMultiplayResult, value);
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
            PointMultiply = ReactiveCommand.Create(() =>
            {
                PointMultiplayResult = TLModel.PointMultiply(PointScalar);
            });
            PointSetMultiply = ReactiveCommand.Create(() =>
            {
                PointSetMultiplayResult = TLModel.PointSetMultiply(PointSetScalar);
            });
            PointEqualityCheck = ReactiveCommand.Create(() =>
            {
                PointEqualityCheckResult = TLModel.PointEqualityCheck(EqualityCheckPoint);
            });
            PointSetEqualityCheck = ReactiveCommand.Create(() =>
            {
                PointSetEqualityCheckResult = TLModel.PointSetEqualityCheck(EqualityCheckPointSet);
            });
            PointUnEqualityCheck = ReactiveCommand.Create(() =>
            {
                PointUnEqualityCheckResult = TLModel.PointUnEqualityCheck(UnEqualityCheckPoint);
            });
            PointSetUnEqualityCheck = ReactiveCommand.Create(() =>
            {
                PointSetUnEqualityCheckResult = TLModel.PointSetUnEqualityCheck(UnEqualityCheckPointSet);
            });
            PointSetOffset = ReactiveCommand.Create(() =>
            {
                OffsetPointSetResult = TLModel.PointSetOffset(OffsetPointSet, IsAdditionOffsetOperation);
            });
        }

        public ReactiveCommand<Unit, Unit> PointMultiply { get; private set; }
        public ReactiveCommand<Unit, Unit> PointSetMultiply { get; private set; }
        public ReactiveCommand<Unit, Unit> PointEqualityCheck { get; private set; }
        public ReactiveCommand<Unit, Unit> PointSetEqualityCheck { get; private set; }
        public ReactiveCommand<Unit, Unit> PointUnEqualityCheck { get; private set; }
        public ReactiveCommand<Unit, Unit> PointSetUnEqualityCheck { get; private set; }
        public ReactiveCommand<Unit, Unit> PointSetOffset { get; private set; }
    }
}

