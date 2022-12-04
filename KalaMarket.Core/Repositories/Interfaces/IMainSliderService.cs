using System.Collections.Generic;
using KalaMarket.DataLayer.Entities;

namespace KalaMarket.Core.Service.Interface
{
    public interface IMainSliderService
    {
        List<MainSlider> ShowAllSliders();
        MainSlider FindSliderBy(int id);
        int AddSlider(MainSlider slider);
        bool UpdateSlider(MainSlider slider);
        bool DeleteSlider(int sliderId);
        bool DeleteSlider(MainSlider slider);
        bool ShiftDeleteSlider(MainSlider slider);
        void Save();
    }
}