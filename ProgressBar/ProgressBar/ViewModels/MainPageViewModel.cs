using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgressBar.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        #region 處理進度百分比
        private double _處理進度百分比 = 0;
        /// <summary>
        /// 處理進度百分比
        /// </summary>
        public double 處理進度百分比
        {
            get { return this._處理進度百分比; }
            set { this.SetProperty(ref this._處理進度百分比, value); }
        }
        #endregion


        #region imageVisible
        private bool _imageVisible = false;
        /// <summary>
        /// imageEnabled
        /// </summary>
        public bool imageVisible
        {
            get { return this._imageVisible; }
            set { this.SetProperty(ref this._imageVisible, value); }
        }
        #endregion

        #region
        private string _處理訊息 = "系統執行中...";
        /// <summary>
        /// 處理訊息
        /// </summary>

        public string 處理訊息
        {
            get { return _處理訊息; }
            set { SetProperty(ref _處理訊息, value); }
        }
        #endregion

        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        private async Task 系統初始化()
        {
            double Per = 0.0;
            await Task.Delay(800);

            for (int i = 0; i < 101; i++)
            {
                Per = i / 100.0;
                處理進度百分比 = Per;
                if (i > 87)
                {
                    imageVisible = true;
                    處理訊息 = "87分不能在高了";
                    await Task.Delay(120);
                }
                else
                {
                    imageVisible = false;
                    處理訊息 = $"{i.ToString()}分";
                    await Task.Delay(100);
                }
            }
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            await 系統初始化();
        }
    }
}
