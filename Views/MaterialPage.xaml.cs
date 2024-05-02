using iscaPopAlvaro.Model;
using iscaPopAlvaro.ViewModel;

namespace iscaPopAlvaro.Views;

[QueryProperty(nameof(Organisme), "OrganismeSelected")]
public partial class MaterialPage : Base.BasePage
{
	private MaterialVM vm;

    private Organisme organisme;
    public Organisme Organisme
    {
        get { return organisme; }
        set { SetProperty(ref organisme, value); vm.assignDadesOrganisme(Organisme); }
    }

    private Material material;
    public Material Material
    {
        get { return material; }
        set { SetProperty(ref material, value); vm.assignDades(material); }
    }



    public MaterialPage()
	{
		InitializeComponent();
        BindingContext = vm = new MaterialVM();
        vm.assignDadesOrganisme(Organisme);
	}

    private async void HacerFotoClick(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(HacerFotoPage)}",
             new Dictionary<string, object>
             {
                 { "Material", Material }
             }
            );
    }

    private void AñadirClick(object sender, EventArgs e)
    {
        string nom = txtNom.Text;
        string uso = txtUso.Text;
        string descripcio = txtDescripcio.Text;
        EnumEstadoMaterial estat = (EnumEstadoMaterial)Enum.Parse(typeof(EnumEstadoMaterial), (string)pickerEstat.SelectedItem);
        Material mat = new Material();
        mat.nom = nom;
        mat.uso = uso;
        mat.descripcio = descripcio;
        mat.estat = estat;
        mat.organisme = Organisme;
        Material = mat;
        vm.insertMaterial(Material);
        Organisme.materialsCollection.Add(mat);
        vm.assignDadesOrganisme(Organisme);
    }
}