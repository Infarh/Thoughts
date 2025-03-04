﻿using System.Collections.ObjectModel;
using System.Windows.Input;

using Thoughts.Domain.Base.Entities;
using Thoughts.UI.MAUI.Services.Interfaces;
using Thoughts.UI.MAUI.ViewModels.Base;

namespace Thoughts.UI.MAUI.ViewModels
{
    public class BlogsViewModel : ViewModel
    {
        private readonly IBlogsManager _blogsManager;


        private string _title = "Blogs";

        public string Title { get => _title; set => Set(ref _title, value); }

        #region Commands

        private ICommand _loadDataCommand;

        public ICommand LoadDataCommand => _loadDataCommand ??= new Command(LoadData);

        #endregion

        public BlogsViewModel(IBlogsManager blogsManager)
        {
            _blogsManager = blogsManager;
        }

        public ObservableCollection<Post> Posts { get; } = new();

        async void LoadData()
        {
            Posts.Clear();

            var posts = await _blogsManager.GetAllInfosAsync();

            foreach (var post in posts)
                Posts.Add(post);
        }
    }
}
