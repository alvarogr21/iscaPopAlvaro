using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace iscaPopAlvaro.Model
{
    [Table("Material")]
    public class Material : Base.BaseModel
    {
        
        private int _id;
        [PrimaryKey, AutoIncrement]
        public int id { get { return _id; } set { SetProperty(ref _id, value); } }
        
        private string _Nom;
        public string Nom { get { return _Nom; } set { SetProperty(ref _Nom, value);  } }

        private string _uso;
        public string Uso { get { return _uso; } set { SetProperty(ref _uso, value); } }

        private EnumEstadoMaterial _estat;
        public EnumEstadoMaterial Estat { get { return _estat; } set { SetProperty(ref _estat, value); } }

        private string _Descripcio;
        public string Descripcio { get { return _Descripcio; } set { SetProperty(ref _Descripcio, value); } }

        private List<Foto> _Fotos;
        [OneToMany(CascadeOperations = CascadeOperation.CascadeInsert | CascadeOperation.CascadeRead)]
        public List<Foto> Fotos
        {
            get { return _Fotos; }
            set
            {
                SetProperty(ref _Fotos, value);
                MaterialsCollection = new ObservableCollection<Foto>(value);
            }
        }

        private ObservableCollection<Foto> _FotosCollection;
        [Ignore]
        public ObservableCollection<Foto> MaterialsCollection
        {
            get { return _FotosCollection; }
            set { SetProperty(ref _FotosCollection, value); }
        }

        [ForeignKey(typeof(Organisme))]
        public int OrganismeId { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.CascadeInsert | CascadeOperation.CascadeRead)]
        public Organisme Organisme { get; set; }
    }
}
