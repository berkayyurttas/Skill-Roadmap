import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ThemeSharedModule, ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { CoreModule, ConfigStateService } from '@abp/ng.core';
import { RouterModule } from '@angular/router';
import { RoadmapService } from '../proxy/roadmaps/roadmap.service';

@Component({
  selector: 'app-roadmaps',
  standalone: true,
  imports: [
    CommonModule, 
    ReactiveFormsModule, 
    ThemeSharedModule, 
    CoreModule,
    RouterModule 
  ],
  templateUrl: './roadmaps.html', 
})
export class RoadmapsComponent implements OnInit {
  roadmaps: any[] = [];
  isModalOpen = false;
  form: FormGroup;
  selectedRoadmapId: string | null = null;

  constructor(
    private roadmapService: RoadmapService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService,
    private configState: ConfigStateService 
  ) {}

  ngOnInit() {
    this.getRoadmaps();
    this.buildForm();
    // Sayfa açıldığında hafızadaki temayı uygula
    this.applyCurrentTheme();
  }

  // --- DARK MODE YÖNETİMİ ---
  toggleDarkMode() {
    const html = document.documentElement;
    const current = html.getAttribute('data-appearance') || 'light';
    const next = current === 'dark' ? 'light' : 'dark';
    
    this.applyTheme(next);
  }

  private applyCurrentTheme() {
    const saved = localStorage.getItem('appearance') || 'light';
    this.applyTheme(saved);
  }

  private applyTheme(mode: string) {
    const html = document.documentElement;
    const body = document.body;

    // 1. HTML Niteliklerini ve Yerel Depolamayı Güncelle
    html.setAttribute('data-appearance', mode);
    localStorage.setItem('appearance', mode);
    
    // 2. CSS Sınıflarını Yönet (LeptonX ve Bootstrap uyumu için)
    if (mode === 'dark') {
      body.classList.add('dark', 'lpx-theme-dark');
      body.classList.remove('light', 'lpx-theme-light');
    } else {
      body.classList.add('light', 'lpx-theme-light');
      body.classList.remove('dark', 'lpx-theme-dark');
    }

    // 3. ABP Global State Güncelleme (Hata almamak için patchState kullanılır)
    // Bu işlem temanın diğer ABP bileşenleri tarafından fark edilmesini sağlar.
    (this.configState as any).patchState({
      appearance: mode
    });
  }

  get isDarkMode(): boolean {
    return document.documentElement.getAttribute('data-appearance') === 'dark';
  }

  // --- YOL HARİTASI İŞLEMLERİ ---
  getRoadmaps() {
    (this.roadmapService as any).getList({ 
      maxResultCount: 10, skipCount: 0, sorting: '' 
    }).subscribe((response) => {
      this.roadmaps = response.items;
    });
  }

  buildForm() {
    this.form = this.fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required],
    });
  }

  createRoadmap() {
    this.selectedRoadmapId = null;
    this.form.reset();
    this.isModalOpen = true;
  }

  editRoadmap(id: string) {
    (this.roadmapService as any).get(id).subscribe((roadmap) => {
      this.selectedRoadmapId = id;
      this.form.patchValue(roadmap);
      this.isModalOpen = true;
    });
  }

  // --- SİLME ÖZELLİĞİ ---
  deleteRoadmap(id: string) {
    this.confirmation.warn(
      'Bu yol haritasını silmek istediğinize emin misiniz?', 
      'Kayıt Silinecek'
    ).subscribe((status: Confirmation.Status) => {
      // status 1 onayı, 0 iptali temsil eder.
      if ((status as any) === 1 || status === Confirmation.Status.confirm) {
        (this.roadmapService as any).delete(id).subscribe(() => {
          this.getRoadmaps();
        });
      }
    });
  }

  save() {
    if (this.form.invalid) return;
    const request = this.selectedRoadmapId
      ? (this.roadmapService as any).update(this.selectedRoadmapId, this.form.value)
      : (this.roadmapService as any).create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.getRoadmaps();
    });
  }
}