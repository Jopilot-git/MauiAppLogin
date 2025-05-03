using System.Threading.Tasks;

namespace MauiAppLogin;

public partial class login : ContentPage
{
	public login()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			List<DadosUsuario> lista_usuario = new List<DadosUsuario>()
			{
				new DadosUsuario()
				{
					Usuario = "Jose",
					Senha = "123"
				},				
				new DadosUsuario() 
				{
					Usuario = "Maria",
					Senha = "321"
					
				}				


			};
			DadosUsuario dados_digitados = new DadosUsuario()
			{
				Usuario = txt_usuario.Text,
				Senha = txt_senha.Text

			};

			// LINQ
			if (lista_usuario.Any(i => (dados_digitados.Usuario == i.Usuario && dados_digitados.Senha == i.Senha))) 
			{
				await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Usuario);
				App.Current.MainPage = new protegida();
			
			} else 
			
			{
				throw new Exception("Usuário ou senha incorreto.");
			
			
			}



		} catch(Exception ex) 
		
		{
			await DisplayAlert("Ops", ex.Message, "Fechar");

		}// Fecha o catch
    } // fecha método
}//fecha a classe