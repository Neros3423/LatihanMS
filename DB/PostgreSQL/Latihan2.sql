PGDMP     6                    |            Latihan2    13.15    13.15 	    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16430    Latihan2    DATABASE     m   CREATE DATABASE "Latihan2" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Indonesian_Indonesia.1252';
    DROP DATABASE "Latihan2";
                postgres    false            �            1259    16433    Trans_Harian    TABLE     �   CREATE TABLE public."Trans_Harian" (
    trans_id bigint NOT NULL,
    keb_det_id bigint,
    peng_id bigint,
    jumlah numeric(18,2),
    keterangan character varying(500),
    tahun character varying(4),
    bulan character varying(2)
);
 "   DROP TABLE public."Trans_Harian";
       public         heap    postgres    false            �            1259    16431    Trans_Harian_trans_id_seq    SEQUENCE     �   ALTER TABLE public."Trans_Harian" ALTER COLUMN trans_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public."Trans_Harian_trans_id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    201            �          0    16433    Trans_Harian 
   TABLE DATA           i   COPY public."Trans_Harian" (trans_id, keb_det_id, peng_id, jumlah, keterangan, tahun, bulan) FROM stdin;
    public          postgres    false    201   �	       �           0    0    Trans_Harian_trans_id_seq    SEQUENCE SET     I   SELECT pg_catalog.setval('public."Trans_Harian_trans_id_seq"', 1, true);
          public          postgres    false    200            $           2606    16440    Trans_Harian Trans_Harian_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public."Trans_Harian"
    ADD CONSTRAINT "Trans_Harian_pkey" PRIMARY KEY (trans_id);
 L   ALTER TABLE ONLY public."Trans_Harian" DROP CONSTRAINT "Trans_Harian_pkey";
       public            postgres    false    201            �   3   x�3�4B#�30�tJ��T�N,J�KTp�,���J�pq��qqq �
�     