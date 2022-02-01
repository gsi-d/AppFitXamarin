using AplicativoFit.Models;
using CurvedEntry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace AplicativoFit.ViewModels
{
    [QueryProperty("PegarIdDaNavegacao", "parametro_id")]
    class CadastroAtividadeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string descricao, observacoes;
        int id;
        DateTime data;
        double? peso;

        CustomEntry cEntry = new CustomEntry();

        public string PegarIdDaNavegacao
        {
            set
            {
                int id_parametro = Convert.ToInt32(Uri.UnescapeDataString(value));

                VerAtividade.Execute(id_parametro);
            }
        }
        public string Descricao
        {
            get => descricao;
            set
            {
                descricao = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Descricao"));
            }
        }

        public string Observacoes
        {
            get => observacoes;
            set
            {
                observacoes = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Observacoes"));
            }
        }

        public int Id
        {
            get => id;
            set
            {
                id = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Id"));
            }
        }

        public DateTime Data
        {
            get => data;
            set
            {
                data = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Data"));
            }
        }

        public double? Peso
        {
            get => peso;
            set
            {
                peso = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Peso"));
            }
        }

        public ICommand NovaAtividade
        {
            get => new Command(() =>
            {
                Id = 0;
                Descricao = String.Empty;
                Data = DateTime.Now;
                Peso = null;
                Observacoes = String.Empty;
            });
        }

        public ICommand SalvarAtividade
        {
            get => new Command(async () =>
           {
               try
               {
                   Atividade model = new Atividade()
                   {
                       Descricao = this.Descricao,
                       Data = this.Data,
                       Peso = this.Peso,
                       Observacoes = this.Observacoes
                   };

                   if (this.Id == 0)
                   {
                       if ((model.Descricao != null) && (model.Data != null) && (model.Peso != null) && (model.Observacoes != null))
                       {
                           await App.Database.Insert(model);
                           await Application.Current.MainPage.DisplayAlert("Beleza!", "Salvo!", "OK");
                           await Shell.Current.GoToAsync("//MinhasAtividades");
                       }
                       else
                       {
                           await Application.Current.MainPage.DisplayAlert("Ops!", "Verifique se todos os campos estão corretos!", "OK");
                           cEntry.BorderColor = Color.Red;
                       }
                   }
                   else
                   {
                       model.Id = this.id;
                       await App.Database.Update(model);
                       await Application.Current.MainPage.DisplayAlert("Beleza!", "Salvo!", "OK");
                   }

               }
               catch (Exception ex)
               {
                   await Application.Current.MainPage.DisplayAlert("Ops!", ex.Message, "OK");
               }
           });
        }

        public ICommand VerAtividade
        {
            get => new Command<int>(async (int id) =>
            {
                try
                {
                    Atividade model = await App.Database.GetById(id);
                    this.id = model.Id;
                    this.Descricao = model.Descricao;
                    this.Peso = model.Peso;
                    this.Data = model.Data;
                    this.Observacoes = model.Observacoes;
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Ops!", ex.Message, "OK");
                }
            });
        }
    }
}