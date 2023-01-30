using Modules.LiveData;

namespace Assets.Common.HitPoints
{
    public class HitPoints
    {
        private MutableLiveData<int> _current = new MutableLiveData<int>();
        private MutableLiveData<int> _max = new MutableLiveData<int>();

        public HitPoints(int maxHitPoints)
        {
            _current.Value = maxHitPoints;
            _max.Value = maxHitPoints;
        }

        public LiveData<int> Current => _current;
        public LiveData<int> Max => _max;
    }
}