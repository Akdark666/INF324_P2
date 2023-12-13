INSERT INTO `flujo` (`id`, `flujo`, `proceso`, `procesosiguiente`, `tipo`, `rol`, `pantalla`) VALUES
(1, 'F1', 'P1', 'P2', 'I', 'universitario', 'p1_obt_r_personales'),
(2, 'F1', 'P2', 'P3', 'P', 'universitario', 'p2_pbt_r_academicos'),
(3, 'F1', 'P3', 'P4', 'P', 'universitario', 'p3_presentacion_doc'),
(4, 'F1', 'P4', NULL, 'C', 'revisor', 'p4_tiene_todo_req'),
(6, 'F1', 'P5', NULL, 'P', 'revisor', 'p5_mostrar_obs'),
(7, 'F1', 'P6', 'P7', 'P', 'entrevistador', 'p6_rev_doc_postulante'),
(8, 'F1', 'P7', 'P8', 'P', 'entrevistador', 'p7_llenar_cuestionario_entrevista'),
(9, 'F1', 'P8', NULL, 'C', 'entrevistador', 'p8_aprobo_la_entrevista'),
(13, 'F1', 'P9', NULL, 'P', 'entrevistador', 'p9_mostrar_observacions'),
(14, 'F1', 'P10', 'P11', 'P', 'entrevistador', 'p10_colocar_a_la_lista_aprobados'),
(15, 'F1', 'P11', NULL, 'P', 'entrevistador', 'p11_publicar_lista_aprobados');