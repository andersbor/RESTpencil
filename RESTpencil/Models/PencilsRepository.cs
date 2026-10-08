namespace RESTpencil.Models
{
    public class PencilsRepository
    {
        private List<Pencil> pencils = new List<Pencil>();
        private int nextId = 1;

        public PencilsRepository(bool includeSampleData = false)
        {
            if (includeSampleData)
            {
                // Initialize with some sample data
                pencils.Add(new Pencil { Id = 1, Color = "Red", Length = 7 });
                pencils.Add(new Pencil { Id = 2, Color = "Blue", Length = 6 });
                pencils.Add(new Pencil { Id = 3, Color = "Green", Length = 8 });
            }
        }

        public List<Pencil> GetAllPencils()
        {
            return pencils.ToList();
        }

        public Pencil? GetPencilById(int id)
        {
            return pencils.FirstOrDefault(p => p.Id == id);
        }

        public Pencil AddPencil(Pencil pencil)
        {
            pencil.Id = nextId++;
            pencils.Add(pencil);
            return pencil;
        }

        public Pencil? UpdatePencil(int id, Pencil updatedPencil)
        {
            var existingPencil = GetPencilById(id);
            if (existingPencil == null)
            {
                return null;
            }
            existingPencil.Color = updatedPencil.Color;
            existingPencil.Length = updatedPencil.Length;
            return existingPencil;
        }

        public Pencil? DeletePencil(int id)
        {
            var pencilToDelete = GetPencilById(id);
            if (pencilToDelete == null)
            {
                return null;
            }
            pencils.Remove(pencilToDelete);
            return pencilToDelete;
        }
    }

}