PGDMP                         |            Latihan    13.15    13.15     �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16394    Latihan    DATABASE     l   CREATE DATABASE "Latihan" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Indonesian_Indonesia.1252';
    DROP DATABASE "Latihan";
                postgres    false            �            1259    16411    Alokasi_Penghasilan    TABLE     �   CREATE TABLE public."Alokasi_Penghasilan" (
    peng_id bigint NOT NULL,
    peng_nama character varying(50),
    peng_persen integer,
    keterangan character varying(250),
    pem_id bigint
);
 )   DROP TABLE public."Alokasi_Penghasilan";
       public         heap    postgres    false            �            1259    16418 	   Kebutuhan    TABLE     �   CREATE TABLE public."Kebutuhan" (
    keb_id bigint NOT NULL,
    keb_nama character varying(50),
    keterangan character varying(250)
);
    DROP TABLE public."Kebutuhan";
       public         heap    postgres    false            �            1259    16425    Kebutuhan_Detail    TABLE     �   CREATE TABLE public."Kebutuhan_Detail" (
    keb_det_id bigint NOT NULL,
    keb_id bigint NOT NULL,
    keb_det_nama character varying(100),
    status character varying(50)
);
 &   DROP TABLE public."Kebutuhan_Detail";
       public         heap    postgres    false            �            1259    16423    Kebutuhan_Detail_keb_det_id_seq    SEQUENCE     �   ALTER TABLE public."Kebutuhan_Detail" ALTER COLUMN keb_det_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Kebutuhan_Detail_keb_det_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    209            �            1259    16416    Kebutuhan_keb_id_seq    SEQUENCE     �   ALTER TABLE public."Kebutuhan" ALTER COLUMN keb_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Kebutuhan_keb_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    207            �            1259    16404 
   Pemasukkan    TABLE     �   CREATE TABLE public."Pemasukkan" (
    pem_id bigint NOT NULL,
    pem_nama character varying(50),
    jumlah numeric(18,2),
    keterangan character varying(250),
    tahun character varying(4),
    bulan character varying(2)
);
     DROP TABLE public."Pemasukkan";
       public         heap    postgres    false            �            1259    16441    List_Pem_Alokasi    VIEW     L  CREATE VIEW public."List_Pem_Alokasi" AS
 SELECT t1.peng_id,
    t1.peng_nama,
    t1.peng_persen,
    t1.keterangan,
    t1.pem_id,
    t2.pem_nama,
    t2.jumlah,
    t2.keterangan AS pem_ket,
    t2.tahun,
    t2.bulan
   FROM (public."Alokasi_Penghasilan" t1
     LEFT JOIN public."Pemasukkan" t2 ON ((t1.pem_id = t2.pem_id)));
 %   DROP VIEW public."List_Pem_Alokasi";
       public          postgres    false    203    205    205    203    203    203    205    205    205    203    203            �            1259    16402    Pemasukkan_pem_id_seq    SEQUENCE     �   ALTER TABLE public."Pemasukkan" ALTER COLUMN pem_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Pemasukkan_pem_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    203            �            1259    16409    Pengeluaran_peng_id_seq    SEQUENCE     �   ALTER TABLE public."Alokasi_Penghasilan" ALTER COLUMN peng_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Pengeluaran_peng_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    205            �            1259    16395    Rencana_Bulanan    TABLE     J  CREATE TABLE public."Rencana_Bulanan" (
    ren_bul_id bigint NOT NULL,
    tahun character varying(4),
    bulan character varying(2),
    pemasukan numeric(18,2),
    pers_peng integer,
    rup_peng numeric(18,2),
    pers_tab integer,
    rup_tab numeric(18,2),
    pers_takterduga integer,
    rup_takterduga numeric(18,2)
);
 %   DROP TABLE public."Rencana_Bulanan";
       public         heap    postgres    false            �            1259    16400    Rencana_Bulanan_ren_bul_id_seq    SEQUENCE     �   ALTER TABLE public."Rencana_Bulanan" ALTER COLUMN ren_bul_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Rencana_Bulanan_ren_bul_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    200            �          0    16411    Alokasi_Penghasilan 
   TABLE DATA           d   COPY public."Alokasi_Penghasilan" (peng_id, peng_nama, peng_persen, keterangan, pem_id) FROM stdin;
    public          postgres    false    205   �$       �          0    16418 	   Kebutuhan 
   TABLE DATA           C   COPY public."Kebutuhan" (keb_id, keb_nama, keterangan) FROM stdin;
    public          postgres    false    207   �$       �          0    16425    Kebutuhan_Detail 
   TABLE DATA           V   COPY public."Kebutuhan_Detail" (keb_det_id, keb_id, keb_det_nama, status) FROM stdin;
    public          postgres    false    209   %       �          0    16404 
   Pemasukkan 
   TABLE DATA           Z   COPY public."Pemasukkan" (pem_id, pem_nama, jumlah, keterangan, tahun, bulan) FROM stdin;
    public          postgres    false    203   4%       �          0    16395    Rencana_Bulanan 
   TABLE DATA           �   COPY public."Rencana_Bulanan" (ren_bul_id, tahun, bulan, pemasukan, pers_peng, rup_peng, pers_tab, rup_tab, pers_takterduga, rup_takterduga) FROM stdin;
    public          postgres    false    200   f%       �           0    0    Kebutuhan_Detail_keb_det_id_seq    SEQUENCE SET     P   SELECT pg_catalog.setval('public."Kebutuhan_Detail_keb_det_id_seq"', 1, false);
          public          postgres    false    208            �           0    0    Kebutuhan_keb_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public."Kebutuhan_keb_id_seq"', 1, false);
          public          postgres    false    206            �           0    0    Pemasukkan_pem_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public."Pemasukkan_pem_id_seq"', 2, true);
          public          postgres    false    202            �           0    0    Pengeluaran_peng_id_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('public."Pengeluaran_peng_id_seq"', 1, true);
          public          postgres    false    204            �           0    0    Rencana_Bulanan_ren_bul_id_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('public."Rencana_Bulanan_ren_bul_id_seq"', 3, true);
          public          postgres    false    201            G           2606    16429 &   Kebutuhan_Detail Kebutuhan_Detail_pkey 
   CONSTRAINT     p   ALTER TABLE ONLY public."Kebutuhan_Detail"
    ADD CONSTRAINT "Kebutuhan_Detail_pkey" PRIMARY KEY (keb_det_id);
 T   ALTER TABLE ONLY public."Kebutuhan_Detail" DROP CONSTRAINT "Kebutuhan_Detail_pkey";
       public            postgres    false    209            E           2606    16422    Kebutuhan Kebutuhan_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY public."Kebutuhan"
    ADD CONSTRAINT "Kebutuhan_pkey" PRIMARY KEY (keb_id);
 F   ALTER TABLE ONLY public."Kebutuhan" DROP CONSTRAINT "Kebutuhan_pkey";
       public            postgres    false    207            A           2606    16408    Pemasukkan Pemasukkan_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public."Pemasukkan"
    ADD CONSTRAINT "Pemasukkan_pkey" PRIMARY KEY (pem_id);
 H   ALTER TABLE ONLY public."Pemasukkan" DROP CONSTRAINT "Pemasukkan_pkey";
       public            postgres    false    203            C           2606    16415 $   Alokasi_Penghasilan Pengeluaran_pkey 
   CONSTRAINT     k   ALTER TABLE ONLY public."Alokasi_Penghasilan"
    ADD CONSTRAINT "Pengeluaran_pkey" PRIMARY KEY (peng_id);
 R   ALTER TABLE ONLY public."Alokasi_Penghasilan" DROP CONSTRAINT "Pengeluaran_pkey";
       public            postgres    false    205            ?           2606    16399 $   Rencana_Bulanan Rencana_Bulanan_pkey 
   CONSTRAINT     n   ALTER TABLE ONLY public."Rencana_Bulanan"
    ADD CONSTRAINT "Rencana_Bulanan_pkey" PRIMARY KEY (ren_bul_id);
 R   ALTER TABLE ONLY public."Rencana_Bulanan" DROP CONSTRAINT "Rencana_Bulanan_pkey";
       public            postgres    false    200            �   -   x�3�H�KO�)M,J�Sp*�I�K��46�,I-.�4����� �
�      �      x������ � �      �      x������ � �      �   "   x�3���44 =���Ȅ���+F��� `�n      �   B   x�3�4202�40�44 =N��1!(����Y�)a�kh U�k�k��G�}1z\\\ ��     