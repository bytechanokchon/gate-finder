import { Injectable } from "@angular/core";
import { PackageDataDto } from "../dtos/packageData.dto";
import { BehaviorSubject } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class PackageDataService {
    packageDatasSubject = new BehaviorSubject<PackageDataDto[]>([]);

    addPackageData(productId: string, productAddress: string): void {
        const currentData = this.packageDatasSubject.getValue();

        const newData: PackageDataDto = {
            productId: productId,
            productAddress: productAddress
        };

        this.packageDatasSubject.next([
            ...currentData,
            newData
        ]);
    }

    getPackageData(): PackageDataDto[] {
        return this.packageDatasSubject.getValue();
    }

    clearPackageData(): void {
        this.packageDatasSubject.next([]);
    }
}