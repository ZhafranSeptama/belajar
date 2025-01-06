using MySql.Data.MySqlClient;
using System;

namespace Tubes
{
  class Program
{
    static string connectionString = "server=127.0.0.1;database= transaksi;uid=root;pwd=";
        

        public static void InputDataTransaksi()
     {
        
        using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("1.pemasukan");
                    Console.WriteLine("2.pengeluaran");
                    Console.Write("Masukkan tipe transaksi: (1/2)");
                    int input = int.Parse(Console.ReadLine()); 
                    string tipetransaksi;
                    
                    if (input == 1){
                        tipetransaksi = "pemasukan";
                    }
                    else {
                        tipetransaksi = "pengeluaran";
                    }
                    Console.WriteLine("masukan jumlah transkasi :");
                    double jumlah_transaksi = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("masukan deskripsi transaksi :");
                    string deskripsi_transaksi = Console.ReadLine();
                    DateTime tanggaltransaksi = DateTime.Now.Date;

                    string query = "INSERT INTO customers (tipe_transaksi, tanggal_transaksi, jumlah_transaksi, deskripsi_transaksi) VALUES (@tipe_transaksi, @tanggal_transaksi, @jumlah_transaksi, @deskripsi_transaksi)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    { 
                        command.Parameters.AddWithValue("@tipe_transaksi", tipetransaksi);
                        command.Parameters.AddWithValue("@tanggal_transaksi", tanggaltransaksi);
                        command.Parameters.AddWithValue("@jumlah_transaksi", jumlah_transaksi);
                        command.Parameters.AddWithValue("@deskripsi_transaksi", deskripsi_transaksi);
                        command.ExecuteNonQuery();
                        Console.WriteLine("Data transaksi berhasil ditambahkan.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }    
     }
    
    public static void Tampilkandata()
    {
        int pilihantampil;
        do 
        {
            Console.WriteLine("tipe transaksi yang ingin di tampilkan : ");
            Console.WriteLine("1. pemasukan");
            Console.WriteLine("2. pengeluaran");
            Console.WriteLine("3. semua");
            Console.WriteLine("4. keluar");
            Console.Write("masukkan tipe transaksi :");
            pilihantampil = int.Parse(Console.ReadLine());
         switch (pilihantampil)
            {
            case 1:
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                try {  
                        Console.WriteLine("================================================================================================");
                        Console.WriteLine("id          Tipe          Transaksi          tanggal                      Deskripsi" );
                        connection.Open();
                        string query = "SELECT * FROM customers WHERE tipe_transaksi = 'pemasukan'";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                
                                while (reader.Read())
                                {
                                    Console.Write( reader["id"] + "          ");
                                    Console.Write( reader["tipe_transaksi"] + "          ");
                                    Console.Write(reader["jumlah_transaksi"] + "          ");
                                    Console.Write(reader["tanggal_transaksi"] + "          ");
                                    Console.WriteLine(reader["deskripsi_transaksi"] + "          ");
                                    
                                }
                                
                            }
                        }
                        Console.WriteLine("================================================================================================");
                     }
                catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
             }   
            break;
            case 2:
            {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                try {
                        Console.WriteLine("================================================================================================");
                        Console.WriteLine("id          Tipe          Transaksi          tanggal                      Deskripsi" );
                        connection.Open();
                        string query = "SELECT * FROM customers WHERE tipe_transaksi = 'pengeluaran'";
                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.Write( reader["id"] + "          ");
                                    Console.Write( reader["tipe_transaksi"] + "          ");
                                    Console.Write(reader["jumlah_transaksi"] + "          ");
                                    Console.Write(reader["tanggal_transaksi"] + "          ");
                                    Console.WriteLine(reader["deskripsi_transaksi"] + "          ");
                                    
                                }
                            }
                        }
                        Console.WriteLine("================================================================================================");
                        
                    }
                    catch (Exception ex)
                    {
                    Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            break;
            case 3 :
            {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
            try {
                    Console.WriteLine("================================================================================================");
                    Console.WriteLine("id          Tipe          Transaksi          tanggal                      Deskripsi" );
                    connection.Open();
                    string query = "SELECT * FROM customers";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.Write(reader["id"] + "          ");
                                Console.Write( reader["tipe_transaksi"] + "          ");
                                Console.Write(reader["jumlah_transaksi"] + "          ");
                                Console.Write(reader["tanggal_transaksi"] + "          ");
                                Console.WriteLine(reader["deskripsi_transaksi"] + "          ");
                                
                            }
                        }
                    }
                    Console.WriteLine("================================================================================================");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        break;
            case 4 :
            Console.WriteLine("kembali ke menu awal ");
            Console.WriteLine("\n");
            break;

            default:
                Console.WriteLine("Pilihan tidak valid.");
                break;    
            }
          
        } while (pilihantampil != 4);
    }
    
       
    
    public static void Caridata()
    {
     using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        try
        {
            connection.Open();
            Console.Write("Masukkan ID transaksi yang ingin dicari: ");
            int idTransaksi = int.Parse(Console.ReadLine());

            string query = "SELECT * FROM customers WHERE id = @id";
            Console.WriteLine("================================================================================================");
            Console.WriteLine("id          Tipe          Transaksi          tanggal                      Deskripsi" ); 
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@id", idTransaksi);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.Write( reader["id"] + "          ");
                        Console.Write( reader["tipe_transaksi"] + "          ");
                        Console.Write(reader["jumlah_transaksi"] + "          ");
                        Console.Write(reader["tanggal_transaksi"] + "          ");
                        Console.WriteLine(reader["deskripsi_transaksi"] + "          ");
                    }
                    else
                    {
                        Console.WriteLine("Data transaksi dengan ID " + idTransaksi + " tidak ditemukan.");
                    }
                }
            }
            Console.WriteLine("================================================================================================");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }     
                    
    }
            
    public static void UpdateData()
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        try
        {
            connection.Open();
            Console.Write("Masukkan ID transaksi yang ingin diperbarui: ");
            int idTransaksi = int.Parse(Console.ReadLine());

            // Mencari data transaksi berdasarkan ID
            string querySelect = "SELECT * FROM customers WHERE id = @id"; 
            using (MySqlCommand commandSelect = new MySqlCommand(querySelect, connection))
            {
                commandSelect.Parameters.AddWithValue("@id", idTransaksi);
                using (MySqlDataReader reader = commandSelect.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        Console.WriteLine("Data transaksi dengan ID " + idTransaksi + " tidak ditemukan.");
                        return;
                    }
                }
            }

            // Meminta input baru dari pengguna
            Console.WriteLine("Masukkan tipe transaksi baru (1 untuk pemasukan, 2 untuk pengeluaran): ");
            int input = int.Parse(Console.ReadLine());
            string tipetransaksi = (input == 1) ? "pemasukan" : "pengeluaran";

            Console.Write("Masukkan jumlah transaksi baru: ");
            double jumlah_transaksi = Convert.ToDouble(Console.ReadLine());

            // Melakukan update data transaksi
            string queryUpdate = "UPDATE customers SET tipe_transaksi = @tipe_transaksi, jumlah_transaksi = @jumlah_transaksi WHERE id = @id";
            using (MySqlCommand commandUpdate = new MySqlCommand(queryUpdate, connection))
            {
                commandUpdate.Parameters.AddWithValue("@tipe_transaksi", tipetransaksi);
                commandUpdate.Parameters.AddWithValue("@jumlah_transaksi", jumlah_transaksi);
                commandUpdate.Parameters.AddWithValue("@id", idTransaksi);
                commandUpdate.ExecuteNonQuery();
                Console.WriteLine("Data transaksi berhasil diperbarui.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
    }
    public static void DeleteData()
    {
        {    using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
            try {
                    Console.WriteLine("================================================================================================");
                    Console.WriteLine("id          Tipe          Transaksi          tanggal                      Deskripsi" );
                    connection.Open();
                    string query = "SELECT * FROM customers";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.Write(reader["id"] + "          ");
                                Console.Write( reader["tipe_transaksi"] + "          ");
                                Console.Write(reader["jumlah_transaksi"] + "          ");
                                Console.Write(reader["tanggal_transaksi"] + "          ");
                                Console.WriteLine(reader["deskripsi_transaksi"] + "          ");
                                
                            }
                        }
                    }
                    Console.WriteLine("================================================================================================");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    {
      using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        try
        {
            connection.Open();
            Console.Write("Masukkan ID transaksi yang ingin dihapus: ");
            int idTransaksi = int.Parse(Console.ReadLine());

            // Mencari data transaksi berdasarkan ID
            string querySelect = "SELECT * FROM customers WHERE id = @id"; // Pastikan 'id' adalah nama kolom ID di tabel Anda
            using (MySqlCommand commandSelect = new MySqlCommand(querySelect, connection))
            {
                commandSelect.Parameters.AddWithValue("@id", idTransaksi);
                using (MySqlDataReader reader = commandSelect.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        Console.WriteLine("Data transaksi dengan ID " + idTransaksi + " tidak ditemukan.");
                        return;
                    }
                }
            }

            // Menghapus data transaksi
            string queryDelete = "DELETE FROM customers WHERE id = @id";
            using (MySqlCommand commandDelete = new MySqlCommand(queryDelete, connection))
            {
                commandDelete.Parameters.AddWithValue("@id", idTransaksi);
                commandDelete.ExecuteNonQuery();
                Console.WriteLine("Data transaksi dengan ID " + idTransaksi + " berhasil dihapus.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }  
    }
    {    using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
            try {
                    Console.WriteLine("================================================================================================");
                    Console.WriteLine("id          Tipe          Transaksi          tanggal                      Deskripsi" );
                    connection.Open();
                    string query = "SELECT * FROM customers";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.Write(reader["id"] + "          ");
                                Console.Write( reader["tipe_transaksi"] + "          ");
                                Console.Write(reader["jumlah_transaksi"] + "          ");
                                Console.Write(reader["tanggal_transaksi"] + "          ");
                                Console.WriteLine(reader["deskripsi_transaksi"] + "          ");
                                
                            }
                        }
                    }
                    Console.WriteLine("================================================================================================");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
    static void Main(string[] args)
    {
       int pilihan;

            do
            {
                TampilkanMenu();
                pilihan = int.Parse(Console.ReadLine());

                switch (pilihan)
                {
                    case 1:
                        InputDataTransaksi();
                        break;
                    case 2:
                        Tampilkandata();
                        break;
                    case 3:
                        Caridata();
                        break;
                    case 4:
                        UpdateData();
                        break;
                    case 5 :
                        DeleteData();
                        break;
                    case 6 : 
                    Console.WriteLine("Terima kasih telah menggunakan aplikasi ini.");
                      break;

                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }
            } while (pilihan != 6);  
    }
    static void TampilkanMenu()
        {
            Console.WriteLine("Menu Transaksi : ");
            Console.WriteLine("1. Tambah Transaksi");
            Console.WriteLine("2. Tampilkan Data transaaksi.");
            Console.WriteLine("3. Cari Data transaksi.");
            Console.WriteLine("4. update data transaksi.");
            Console.WriteLine("5. Hapus data transaksi.");
            Console.WriteLine("6. Keluar");
            Console.Write("Pilih menu: ");
        }
  }
}