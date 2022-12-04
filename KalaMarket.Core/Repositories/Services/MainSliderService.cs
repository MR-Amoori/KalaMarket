using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KalaMarket.Core.Service.Interface;
using KalaMarket.DataLayer.Context;
using KalaMarket.DataLayer.Entities;

namespace KalaMarket.Core.Repositories.Services
{
    public class MainSliderService : IMainSliderService
    {
        private readonly KalaMarketContext _context;

        public MainSliderService(KalaMarketContext context)
        {
            _context = context;
        }

        public List<MainSlider> ShowAllSliders()
        {
            //if (page != null)
            //{
            //    int skip = (page.Value - 1) * 3; 
            //    return _context.MainSliders.Where(x => !x.IsDeleted)
            //        .OrderBy(x => x.SliderSort).Skip(skip).Take(3).ToList();
            //}
            return _context.MainSliders.Where(x => !x.IsDeleted).OrderBy(x=>x.SliderSort).ToList();
        }

        public MainSlider FindSliderBy(int id)
        {
            return _context.MainSliders
                .Where(x => !x.IsDeleted)
                .FirstOrDefault(x => x.SliderId == id);
        }

        public int AddSlider(MainSlider slider)
        {
            try
            {
                _context.MainSliders.Add(slider);
                Save();
                return slider.SliderId;
            }
            catch
            {
                return 0;
            }
        }

        public bool UpdateSlider(MainSlider slider)
        {
            try
            {
                _context.MainSliders.Update(slider);
                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteSlider(int sliderId)
        {
            try
            {
                MainSlider sliderTarget = FindSliderBy(sliderId);
                return DeleteSlider(sliderTarget);
            }
            catch
            {
                return false;
            }
        }

        public bool ShiftDeleteSlider(MainSlider slider)
        {
            try
            {
                _context.MainSliders.Remove(slider);
                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }
      
        public bool DeleteSlider(MainSlider slider)
        {
            try
            {
                slider.IsDeleted = true;
                Save();
                return true;
            }
            catch
            {
                return false;
            }
        }
     
        public void Save()
        {
            _context.SaveChanges();
        }

        public int SlidersCount()
        {
            var slidersCount = _context.MainSliders.Where(x => !x.IsDeleted).Count();
            if (slidersCount % 2 != 0)
            {
                slidersCount++;
            }

            slidersCount = slidersCount / 2;
            return slidersCount;
        }
    }
}