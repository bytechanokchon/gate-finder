import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ImageUpload } from '../../components/image-upload/image-upload';
import { PackageDataService } from '../../services/packageData.service';
import { PackageDataDto } from '../../dtos/packageData.dto';
import { GateService } from '../../services/gate.service';
import { SearchGateResponseDto } from '../../dtos/gate.dto';

@Component({
  imports: [ImageUpload],
  selector: 'app-gate-list',
  styleUrl: './gate-list.css',
  templateUrl: './gate-list.html',
})
export class GateList implements OnInit {
  packageDatas: PackageDataDto[] = [];
  gateDatas: SearchGateResponseDto[] = [];

  constructor(
    private packageDataService: PackageDataService,
    private changeDetector: ChangeDetectorRef,
    private gateService: GateService
  ) { }

  ngOnInit(): void {
    this.packageDataService.packageDatasSubject.subscribe((value) => {
      if (value.length > 0) {
        this.packageDatas = value;

        this.gateService.search(value).subscribe((response) => {
          if (response.isSuccess && response.data != null) {
            this.gateDatas = response.data;
            this.changeDetector.detectChanges();
          }
        })
      }
    });
  }
}
