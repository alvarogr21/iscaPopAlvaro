using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.ObjectModel;

namespace iscaPopAlvaro.Model
{
    [Table("Organisme")]
    public class Organisme : Base.BaseModel
    {

        private int _id;
        [PrimaryKey, AutoIncrement]
        public int ID { get { return _id; } set { SetProperty(ref _id, value); } }

        private string _Codi;
        public string Codi { get { return _Codi; } set { SetProperty(ref _Codi, value); } }

        private string _password;
        public string Password { get { return _password; } set { SetProperty(ref _password, value); } }

        private string _Nom;
        public string Nom { get { return _Nom; } set { SetProperty(ref _Nom, value); } }

        private string _Email;
        public string Email { get { return _Email; } set { SetProperty(ref _Email, value); } }

        private DateTime _momento;
        public DateTime Momento { get { return _momento; } set { SetProperty(ref _momento, value); } }

        private List<Material> _Materials;
        [OneToMany(CascadeOperations = CascadeOperation.CascadeInsert | CascadeOperation.CascadeRead)]
        public List<Material> Materials
        {
            get { return _Materials; }
            set
            {
                SetProperty(ref _Materials, value);
                MaterialsCollection = new ObservableCollection<Material>(value);
            }
        }

        private ObservableCollection<Material> _MaterialsCollection;


        [Ignore]
        public ObservableCollection<Material> MaterialsCollection
        {
            get { return _MaterialsCollection; }
            set { SetProperty(ref _MaterialsCollection, value); }
        }
    }
}
