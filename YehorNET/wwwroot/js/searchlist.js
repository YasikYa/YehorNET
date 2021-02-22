class DataList {
	constructor(containerId, inputId, idInputId, listId, options) {
		this.containerId = containerId;
		this.inputId = inputId;
        this.idInputId = idInputId;
		this.listId = listId;
		this.options = options;
	}

	create(filter = "") {
		const list = document.getElementById(this.listId);
		const filterOptions = this.options.filter(
			d => filter === "" || d.name.includes(filter)
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
        const idInput = document.getElementById(this.idInputId);
		container.addEventListener("click", e => {
			if (e.target.id === this.inputId) {
				container.classList.toggle("active");
			} else if (e.target.id === "datalist-icon") {
				container.classList.toggle("active");
				input.focus();
			}
		});

		input.addEventListener("input", function(e) {
			if (!container.classList.contains("active")) {
				container.classList.add("active");
			}

			datalist.create(input.value);
		});

		list.addEventListener("click", function(e) {
			if (e.target.nodeName.toLocaleLowerCase() === "li") {
				input.value = e.target.innerText;
				container.classList.remove("active");
                idInput.value = e.target.id;
			}
		});
	}
}
