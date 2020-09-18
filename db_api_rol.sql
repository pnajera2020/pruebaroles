--
-- PostgreSQL database dump
--

-- Dumped from database version 12.2
-- Dumped by pg_dump version 12.2

-- Started on 2020-09-18 15:39:39

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 202 (class 1259 OID 26207)
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- TOC entry 204 (class 1259 OID 26214)
-- Name: cat_permiso; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.cat_permiso (
    id_permiso bigint NOT NULL,
    ds_descripcion text,
    "b_Activo" boolean NOT NULL
);


ALTER TABLE public.cat_permiso OWNER TO postgres;

--
-- TOC entry 203 (class 1259 OID 26212)
-- Name: cat_permiso_id_permiso_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.cat_permiso ALTER COLUMN id_permiso ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public.cat_permiso_id_permiso_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 206 (class 1259 OID 26224)
-- Name: cat_rol; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.cat_rol (
    id_rol bigint NOT NULL,
    ds_descripcion text,
    "b_Activo" boolean NOT NULL
);


ALTER TABLE public.cat_rol OWNER TO postgres;

--
-- TOC entry 205 (class 1259 OID 26222)
-- Name: cat_rol_id_rol_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.cat_rol ALTER COLUMN id_rol ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public.cat_rol_id_rol_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 208 (class 1259 OID 26234)
-- Name: tb_rol_permiso; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.tb_rol_permiso (
    id_rol_permiso bigint NOT NULL,
    id_rol bigint NOT NULL,
    id_permiso bigint NOT NULL,
    b_activo boolean NOT NULL
);


ALTER TABLE public.tb_rol_permiso OWNER TO postgres;

--
-- TOC entry 207 (class 1259 OID 26232)
-- Name: tb_rol_permiso_id_rol_permiso_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.tb_rol_permiso ALTER COLUMN id_rol_permiso ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public.tb_rol_permiso_id_rol_permiso_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 2843 (class 0 OID 26207)
-- Dependencies: 202
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
20200918162140_wsx	3.1.8
\.


--
-- TOC entry 2845 (class 0 OID 26214)
-- Dependencies: 204
-- Data for Name: cat_permiso; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.cat_permiso (id_permiso, ds_descripcion, "b_Activo") FROM stdin;
1	Comprar	t
2	Vender	t
3	Rentar	t
\.


--
-- TOC entry 2847 (class 0 OID 26224)
-- Dependencies: 206
-- Data for Name: cat_rol; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.cat_rol (id_rol, ds_descripcion, "b_Activo") FROM stdin;
1	Casi Todo lo puede	t
2	Todo lo puede	t
3	Nada puede	t
4	Nada puede	t
5	Nada puede	t
\.


--
-- TOC entry 2849 (class 0 OID 26234)
-- Dependencies: 208
-- Data for Name: tb_rol_permiso; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.tb_rol_permiso (id_rol_permiso, id_rol, id_permiso, b_activo) FROM stdin;
1	1	1	t
2	1	2	t
3	1	3	t
\.


--
-- TOC entry 2855 (class 0 OID 0)
-- Dependencies: 203
-- Name: cat_permiso_id_permiso_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.cat_permiso_id_permiso_seq', 3, true);


--
-- TOC entry 2856 (class 0 OID 0)
-- Dependencies: 205
-- Name: cat_rol_id_rol_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.cat_rol_id_rol_seq', 5, true);


--
-- TOC entry 2857 (class 0 OID 0)
-- Dependencies: 207
-- Name: tb_rol_permiso_id_rol_permiso_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.tb_rol_permiso_id_rol_permiso_seq', 3, true);


--
-- TOC entry 2706 (class 2606 OID 26211)
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- TOC entry 2708 (class 2606 OID 26221)
-- Name: cat_permiso PK_cat_permiso; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cat_permiso
    ADD CONSTRAINT "PK_cat_permiso" PRIMARY KEY (id_permiso);


--
-- TOC entry 2710 (class 2606 OID 26231)
-- Name: cat_rol PK_cat_rol; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.cat_rol
    ADD CONSTRAINT "PK_cat_rol" PRIMARY KEY (id_rol);


--
-- TOC entry 2714 (class 2606 OID 26238)
-- Name: tb_rol_permiso PK_tb_rol_permiso; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tb_rol_permiso
    ADD CONSTRAINT "PK_tb_rol_permiso" PRIMARY KEY (id_rol_permiso);


--
-- TOC entry 2711 (class 1259 OID 26249)
-- Name: IX_tb_rol_permiso_id_permiso; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_tb_rol_permiso_id_permiso" ON public.tb_rol_permiso USING btree (id_permiso);


--
-- TOC entry 2712 (class 1259 OID 26250)
-- Name: IX_tb_rol_permiso_id_rol; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_tb_rol_permiso_id_rol" ON public.tb_rol_permiso USING btree (id_rol);


--
-- TOC entry 2715 (class 2606 OID 26239)
-- Name: tb_rol_permiso fk_cat_permiso_id_permiso; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tb_rol_permiso
    ADD CONSTRAINT fk_cat_permiso_id_permiso FOREIGN KEY (id_permiso) REFERENCES public.cat_permiso(id_permiso) ON DELETE CASCADE;


--
-- TOC entry 2716 (class 2606 OID 26244)
-- Name: tb_rol_permiso fk_cat_rol_id_rol; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.tb_rol_permiso
    ADD CONSTRAINT fk_cat_rol_id_rol FOREIGN KEY (id_rol) REFERENCES public.cat_rol(id_rol) ON DELETE CASCADE;


-- Completed on 2020-09-18 15:39:39

--
-- PostgreSQL database dump complete
--
