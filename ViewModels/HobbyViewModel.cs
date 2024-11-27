﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfHobbyList.Models;

namespace WpfHobbyList.ViewModels
{
    public class HobbyViewModel : ViewModelBase
    {
		private ObservableCollection<Hobby> hobbies=new();
        private Hobby selectedHobby;
		public ObservableCollection<Hobby> Hobbies
		{
			get { return hobbies; }
			set { hobbies = value;
                RaisePropertyChanged();
            }
		}
        
        public Hobby SelectedHobby
        {
            get { return selectedHobby; }
            set { selectedHobby = value;
                RaisePropertyChanged();
            }
        }

        public HobbyViewModel()
        {
            hobbies.Add(new Hobby() { Description="Äta olja", Active=true});
            hobbies.Add(new Hobby() { Description = "Dricka sand", Active = true });
            hobbies.Add(new Hobby() { Description = "Spela i arabiska heavy metal-band", Active = false });
        }
              
        public async Task LoadAsync()
        {
            if (Hobbies.Any())
            {
                return;
            }         
        }

        public void AddStudent()
        {
            Hobby hobby = new Hobby() { Description = "Ny hobby" };
            Hobbies.Add(hobby);
            SelectedHobby = hobby;
        }
    }
}
