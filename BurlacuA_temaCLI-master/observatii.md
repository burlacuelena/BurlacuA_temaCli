1. Cu coordonatele `GL.Ortho(-5.0, 5.0, -5.0, 1.0, 0.0, 4.0)`, scena va fi vizibilă într-un volum cu un câmp de vedere de 10 unități pe axa X (între -5 și 5) și 6 unități pe axa Y (între -5 și 1), iar adâncimea pe axa Z va fi între 0 și 4. Triunghiul ar putea apărea redimensionat sau translatat, depinzând de cum se încadrează în acest nou volum.
   Triunghiul apare mai centrat cu varful in jos.

1. Un viewport în contextul graficii și al bibliotecii OpenGL reprezintă o zonă rectangulară din fereastra de afișare unde OpenGL va desena și randa scenele grafice. 

2. Frames per second (FPS) reprezintă numărul de cadre sau imagini randate pe secundă de către motorul grafic utilizând OpenGL. Este o măsură a performanței aplicației și reflectă cât de repede poate sistemul să calculeze și să afișeze scenele grafice.

3. Metoda OnUpdateFrame() este rulată în cadrul ciclului de viață al unei aplicații OpenGL pentru a actualiza logica jocului sau a aplicației înainte ca un nou cadru să fie randat. Aceasta este momentul în care se actualizează starea scenelor, mișcarea obiectelor, fizica, detectarea coliziunilor etc. 

4. Modul imediat de randare (în engleză immediate mode rendering) este un mod vechi și mai simplu de randare din OpenGL, în care fiecare vertebră și primitivă grafică este specificată și desenată direct de către CPU pentru fiecare cadru.

5. Modul imediat de randare a fost deprecate începând cu versiunea OpenGL 3.0, iar începând cu OpenGL 3.1, modul imediat a fost complet eliminat din profilul core (profilul principal al OpenGL).

6. Metoda OnRenderFrame() este rulată de fiecare dată când trebuie randat un nou cadru grafic. Aceasta conține codul de randare și este responsabilă pentru desenarea obiectelor pe ecran.

7. Metoda OnResize() trebuie executată cel puțin o dată pentru a configura corect viewport-ul și proiecția scenei în momentul în care dimensiunea ferestrei de vizualizare se schimbă sau la inițializarea aplicației. Dacă nu este executată, viewport-ul ar putea să nu fie corect configurat, ceea ce ar putea duce la deformarea scenei sau la afișarea incorectă a obiectelor grafice.

8. Metoda CreatePerspectiveFieldOfView() (sau echivalentele ei în alte biblioteci grafice, cum ar fi gluPerspective() în OpenGL) este folosită pentru a crea o matrice de proiecție perspective, care definește modul în care obiectele 3D sunt proiectate pe un ecran 2D. Parametrii tipici pentru această metodă sunt:

   field of view (FOV) – reprezintă unghiul de deschidere al câmpului vizual, exprimat în grade. Acesta controlează cât de larg este câmpul de vedere. Domeniul de valori este de obicei între 30 și 120 de grade, unde o valoare mai mică produce un efect de zoom, iar o valoare mai mare produce un câmp de vedere larg.

   aspect ratio – reprezintă raportul dintre lățimea și înălțimea ferestrei de vizualizare (de exemplu, lățime/înălțime). Aceasta asigură că imaginea nu este distorsionată în timpul proiecției.

   near plane – reprezintă distanța de la camera virtuală până la planul apropiat de tăiere. Orice obiect care se află mai aproape de acest plan va fi eliminat din scenă. Domeniul valorilor este pozitiv și tipic, începând de la o valoare mică, de exemplu, 0.1.

   far plane – reprezintă distanța de la camera virtuală până la planul îndepărtat de tăiere. Orice obiect dincolo de acest plan nu va fi vizibil. Valori tipice sunt de ordinul miilor, cum ar fi 1000 sau 2000.
