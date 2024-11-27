using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfHobbyList.Command;
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
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand AddCommand { get; }
        public DelegateCommand DeleteCommand { get; }

        public HobbyViewModel()
        {
            hobbies.Add(new Hobby() { Description="Äta olja", Active=true});
            hobbies.Add(new Hobby() { Description = "Dricka sand", Active = true });
            hobbies.Add(new Hobby() { Description = "Spela i arabiska heavy metal-band", Active = false });

            AddCommand = new DelegateCommand(AddHobby);
            DeleteCommand = new DelegateCommand(DeleteHobby, CanDelete);
        }

        private void DeleteHobby(object? parameter)
        {
            if (SelectedHobby != null)
            {
                Hobbies.Remove(SelectedHobby);
                SelectedHobby = null;
            }
        }

        private bool CanDelete(object? parameter) => SelectedHobby != null;
        
        public async Task LoadAsync()
        {
            if (Hobbies.Any())
            {
                return;
            }         
        }

        private void AddHobby(object? parameter)
        {
            Hobby hobby = new Hobby() { Description = "Ny hobby" };
            Hobbies.Add(hobby);
            SelectedHobby = hobby;
        }
    }
}
