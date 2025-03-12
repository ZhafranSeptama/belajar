/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package Dasar_pbo;
import java.util.Scanner;
/**
 *
 * @author zhafran
 */
public class pertemuaan4 {
    static String Nama;
    static String PilihHotel;
    static String Alamat;
    static String tujuan;
    static int NoKtp;
    static int Lama;
    static int TourMenu;
    static int Harga;
    static int HargaHotel;
    
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);
        System.out.println("======= selamat datang di aplikasi =======");
        Tour();
        identitas();
        if (TourMenu == 1){
          Pilihan1();  
        }else if (TourMenu == 2){
          pilihan2();
        }else if(TourMenu == 3){
            System.out.println("=====TERIMAKASIH=====");
        }else {
            System.out.println("Input tidak valid");
            System.exit(0);
        }
        outputHasil();
        
    }
    public static void Tour(){
        Scanner input = new Scanner(System.in);
        
        System.out.println("====Pilihan Tour Travel====");
        System.out.println("=========================");
        System.out.println("[1]. Domestik");
        System.out.println("[2]. Mancanegara");
        System.out.println("[3]. Keluar");
        System.out.println("=========================");
        System.out.print("pilihan: ");
        TourMenu = input.nextInt();
    }
    
    
    public static void identitas(){
        Scanner input = new Scanner(System.in);
        
        System.out.println("===============Masukkan identitas travel=============");
        System.out.println("nama :");
        Nama = input.nextLine();
        System.out.println("No.KTP :");
        NoKtp = input.nextInt();
         input.nextLine();
        System.out.println("Alamat :");
        Alamat = input.nextLine();
        
    }
    public static void pilihan2(){
         Scanner input = new Scanner(System.in);
        
        System.out.println("===============Tempat tujuan tour travel=============");
        System.out.println("==================================");
        System.out.println("[a]. Amerika        [B]. Italy");
        System.out.println("[C]. Inggris        [D]. Belanda");
        System.out.println("[E]. Brazil         [F]. Korea");
        System.out.println("===================================");
        System.out.println("masukan kode tujuan (huruf Kapital):");
        String KodeTujuan1 = input.nextLine();
        if(KodeTujuan1.equals("A")){
            Harga = 20000000;
            tujuan = "Amerika";
        }else if (KodeTujuan1.equals("B")){
            Harga = 20000000;
           tujuan = "Italy";
        }else if (KodeTujuan1.equals("C")){
            Harga = 30000000;
           tujuan = "Inggris";
        }else if (KodeTujuan1.equals("D")){
            Harga = 40000000;
           tujuan = "Belanda";
        }else if (KodeTujuan1.equals("E")){
            Harga = 50000000;
           tujuan = "Brazil";
        }else if (KodeTujuan1.equals("F")){
            Harga = 10000000;
           tujuan = "Korea";
        }else {
            System.out.println("Kode yang di inputkan salah");
            System.exit(0);
        }
        System.out.println("Masukan Lama Tour :");
        Lama = input.nextInt();
        input.nextLine();
        System.out.println("Memakai Hotel: Y/T");
        PilihHotel = input.nextLine();
        if(PilihHotel.equals("Y")){
            HargaHotel = 250000;
        }else{
            HargaHotel = 0;
        }
        
        input.close();
    }
    public static void Pilihan1(){
        Scanner input = new Scanner(System.in);
        
        System.out.println("===============Tempat tujuan tour travel=============");
        System.out.println("==================================");
        System.out.println("[a]. Bandung     [B].Bali");
        System.out.println("[C]. Papua       [D].Medan");
        System.out.println("[E]. padang      [F].Balikpapan");
        System.out.println("===================================");
        System.out.println("masukan kode tujuan (huruf Kapital):");
        String KodeTujuan = input.nextLine();
        
        if(KodeTujuan.equals("A")){
            Harga = 200000;
            tujuan = "Bandung";
        }else if (KodeTujuan.equals("B")){
            Harga = 300000;
           tujuan = "Bali"; 
        }else if (KodeTujuan.equals("C")){
            Harga = 400000;
           tujuan = "Papua"; 
        }else if (KodeTujuan.equals("D")){
            Harga = 500000;
           tujuan = "Medan"; 
        }else if (KodeTujuan.equals("E")){
            Harga = 100000;
           tujuan = "Padang"; 
        }else if (KodeTujuan.equals("F")){
            Harga = 600000;
           tujuan = "Balikpapan"; 
        }else {
           System.out.println("Kode yang di inputkan salah ");
            System.exit(0);
        }
        System.out.println("Masukan Lama Tour :");
        Lama = input.nextInt();
        input.nextLine();
        System.out.println("Memakai Hotel: Y/T");
        PilihHotel = input.nextLine();
        if(PilihHotel.equals("Y")){
            HargaHotel = 250000;
        }else{
            HargaHotel = 0;
        }
        input.close();
       }
    public static void outputHasil(){
        int TotalHarga = Harga + HargaHotel;
        int PPN = TotalHarga *10/100;
        int total = TotalHarga + PPN * Lama;
        System.out.println("========================================");
        System.out.println("               Tour Travel              ");
        System.out.println("========================================");
        System.out.println("Nama               : " + Nama);
        System.out.println("No KTP             : " + NoKtp);
        System.out.println("Alamat             : " + Alamat);
        System.out.println("Tempat Tujuan      : " + tujuan);
        System.out.println("Lama Tour          : " + Lama + " hari");
        System.out.println("Biaya Perjalanan   : " + Harga);
        System.out.println("Biaya Hotel        : " + HargaHotel);
        System.out.println("Total Biaya        : " + TotalHarga);
        System.out.println("PPN 10%            : " + PPN);
        System.out.println("Total Pembayaran   : " + total);
        System.out.println("========================================");
        System.out.println("                selesai                 ");
        System.out.println("========================================");
        }
    }


        
        
        
        
        

    

