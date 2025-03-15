/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package Dasar_pbo;
/**
 *
 * @author zhafran
 */
import java.util.Scanner;
public class Kalkulator {
    
    static int Bil_A;
    static int Bil_B;
    static int pil;
    static int tambah;
    static int kurang;
    static int kali;
    static double bagi;
    public static void main(String[] args){
        Scanner input = new Scanner(System.in);
        
        System.out.println("kalkulator sederhana");
        System.out.println("pilih metode");
        System.out.println("1. tambah");
        System.out.println("2. Kurang");
        System.out.println("3. Kali");
        System.out.println("4. Bagi");
        System.out.println("masukan pilihan :");
        pil = input.nextInt();
        System.out.println("masukan angka 1:");
        Bil_A = input.nextInt();
        System.out.println("masukan angka 2:");
        Bil_B= input.nextInt();
        
        switch(pil){
            case 1 :
                nambah();
                System.out.println("hasil = "+ tambah);
                break;
            case 2:
                kurang();
                System.out.println("hasil = "+ kurang);
                break;
            case 3 :
                kali();
                System.out.println("hasil = "+ kali);
                break;
            case 4:
                bagi();
                System.out.println("hasil = "+ bagi);
                break;
        }
        
    }
    public static void nambah(){
        tambah = Bil_A+ Bil_B;
    }
    public static void kurang(){
        kurang = Bil_A - Bil_B;
    }
    public static void bagi(){
        kali = Bil_A * Bil_B;
    }
    public static void kali(){
        bagi = Bil_A / Bil_B;
    }
}
