class MultiDataList {
    constructor(containerId, inputId, selectContainerId, listId, options) {
        this.containerId = containerId;
        this.inputId = inputId;
        this.selectContainerId = selectContainerId;
        this.listId = listId;
        this.options = options;
        this.selected = [];
    }

    create(filter = "") {
        const list = document.getElementById(this.listId);
        const filterOptions = this.options.filter(
            d => (filter === "" || d.name.includes(filter)) && !this.selected.includes(d.id)
        );

        if (filterOptions.length === 0) {
            list.classList.remove("active");
        } else {
            list.classList.add("active");
        }

        list.innerHTML = filterOptions
            .map(o => `<li id=${o.id}>${o.name}</li>`)
            .join("");
    }

    addListeners(datalist) {
        const container = document.getElementById(this.containerId);
        const input = document.getElementById(this.inputId);
        const list = document.getElementById(this.listId);
        const selectContainerId = document.getElementById(this.selectContainerId);
        container.addEventListener("click", e => {
            if (e.target.id === this.inputId) {
                container.classList.toggle("active");
            } else if (e.target.id === "datalist-icon") {
                container.classList.toggle("active");
                input.focus();
            }
        });

        input.addEventListener("input", function (e) {
            if (!container.classList.contains("active")) {
                container.classList.add("active");
            }

            datalist.create(input.value);
        });

        list.addEventListener("click", (e) => {
            if (e.target.nodeName.toLocaleLowerCase() === "li") {
                container.classList.remove("active");
                selectContainerId.insertAdjacentHTML("beforeend", `
                    <div id=${e.target.id}>
                        <input type='hidden' value=${e.target.id} name='Treats' />
                        <button class="btn btn-outline-primary" style="margin-right: 10px;">
                            <span>${e.target.innerHTML}</span>
                            <svg width="15" height="15" viewBox="0 0 20 20">
                                <path fill="currentColor" d="M17.453.667L10 8.12 2.547.667l-1.88 1.88L8.12 10 .667 17.453l1.88 1.88L10 11.88l7.453 7.453 1.88-1.88L11.88 10l7.453-7.453z"></path>
                            </svg>
                        </button>
                    </div>
                `);
                this.selected.push(e.target.id);
                datalist.create(input.value);

                const inserted = document.getElementById(e.target.id);
                inserted.addEventListener("click", (e) => {
                    // TODO: Create delete icon on hover
                    this.selected.splice(this.selected.indexOf(e.target.id), 1);
                    inserted.remove();
                    datalist.create(input.value);
                });
            }
        });
    }
}